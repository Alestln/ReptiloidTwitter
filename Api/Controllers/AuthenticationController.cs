using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using System.Security.Claims;
using Application.Domain.Accounts.Commands.CreateAccount;
using Application.Domain.Accounts.Queries.GetAccount;
using Application.Domain.RefreshTokens.Commands.CreateRefreshToken;
using Application.Domain.RefreshTokens.Commands.DeleteRefreshToken;
using Application.Domain.RefreshTokens.Queries.GetRefreshToken;
using Application.Dtos.Accounts;
using Application.Dtos.Authentication;
using AutoMapper;
using Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReptiloidTwitter.Common;
using ReptiloidTwitter.Services.Authentication;

namespace ReptiloidTwitter.Controllers;

[Route("api/[controller]/[action]")]
public class AuthenticationController(
    IMediator mediator,
    IMapper mapper,
    IJwtAuthenticationService authenticationService) : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] [Required] CreateAccountDto model,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var command = mapper.Map<CreateAccountCommand>(model);
            var account = await mediator.Send(command, cancellationToken);

            var authenticationResponse = authenticationService.GenerateTokens(account);
            
            var createRefreshTokenCommand = new CreateRefreshTokenCommand(authenticationResponse.RefreshToken, account.Id,
                authenticationResponse.RefreshTokenExpiration);

            await mediator.Send(createRefreshTokenCommand, cancellationToken);
            
            return Ok(authenticationResponse);
        }
        catch (AuthenticationException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Login(
        [FromBody] [Required] LoginRequest request,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var query = new GetAccountByLoginQuery(request.Login, request.Password);
            var account = await mediator.Send(query, cancellationToken);

            var authenticationResponse = authenticationService.GenerateTokens(account);
            
            var createCommand = new CreateRefreshTokenCommand(authenticationResponse.RefreshToken, account.Id,
                authenticationResponse.RefreshTokenExpiration);

            await mediator.Send(createCommand, cancellationToken);
            
            return Ok(authenticationResponse);
        }
        catch (AuthenticationException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Refresh(
        [FromBody] RefreshTokenRequestModel model,
        CancellationToken cancellationToken = default)
    {
        var query = new GetRefreshTokenQuery(model.RefreshToken);
        var refreshToken = await mediator.Send(query, cancellationToken);

        if (refreshToken is null)
        {
            return Unauthorized("Incorrect refresh token.");
        }

        var deleteCommand = new DeleteRefreshTokenCommand(model.RefreshToken);
        await mediator.Send(deleteCommand, cancellationToken);
        
        var account = refreshToken.Account;
        
        var authenticationResponse = authenticationService.GenerateTokens(account);
        
        var createCommand = new CreateRefreshTokenCommand(authenticationResponse.RefreshToken, account.Id,
            authenticationResponse.RefreshTokenExpiration);

        await mediator.Send(createCommand, cancellationToken);

        return Ok(authenticationResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Logout(
        [FromBody] RefreshTokenRequestModel model,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var deleteCommand = new DeleteRefreshTokenCommand(model.RefreshToken);
            await mediator.Send(deleteCommand, cancellationToken);

            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> LogoutFromAllDevices(
        CancellationToken cancellationToken = default)
    {
        var accountIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (accountIdClaim is null || !Guid.TryParse(accountIdClaim.Value, out var accountId))
        {
            return BadRequest("Failed to get user ID from token.");
        }
        
        await authenticationService.InvalidateTokensAsync(accountId, cancellationToken);

        return Ok();
    }
}