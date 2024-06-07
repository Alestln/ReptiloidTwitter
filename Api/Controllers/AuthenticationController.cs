using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using Application.Domain.Accounts.Commands.CreateAccount;
using Application.Domain.Accounts.Queries.GetAccount;
using Application.Domain.RefreshTokens.Commands;
using Application.Dtos.Accounts;
using Application.Dtos.Authentication;
using AutoMapper;
using MediatR;
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

            var response = authenticationService.GenerateTokens(account);

            return Ok(response);
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

            var command = new CreateRefreshTokenCommand(authenticationResponse.RefreshToken, account.Id,
                authenticationResponse.RefreshTokenExpiration);

            await mediator.Send(command, cancellationToken);
            
            return Ok(authenticationResponse);
        }
        catch (AuthenticationException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Logout(
        [Required] Guid accountId,
        CancellationToken cancellationToken = default)
    {
        await authenticationService.InvalidateTokensAsync(accountId, cancellationToken);

        return Ok();
    }
}