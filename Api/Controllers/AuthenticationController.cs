using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using Application.Domain.Accounts.Commands.CreateAccount;
using Application.Domain.Accounts.Queries.GetAccount;
using Application.Domain.RefreshTokens.Commands;
using Application.Domain.RefreshTokens.Commands.CreateRefreshToken;
using Application.Domain.RefreshTokens.Commands.UpdateRefreshToken;
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
            
            if (string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                var createCommand = new CreateRefreshTokenCommand(authenticationResponse.RefreshToken, account.Id,
                    authenticationResponse.RefreshTokenExpiration);

                await mediator.Send(createCommand, cancellationToken);
            }
            else
            {
                var updateCommand = new UpdateRefreshTokenCommand(
                    account.Id, 
                    request.RefreshToken,
                    authenticationResponse.RefreshToken,
                    authenticationResponse.RefreshTokenExpiration);

                await mediator.Send(updateCommand, cancellationToken);
            }
            
            return Ok(authenticationResponse);
        }
        catch (AuthenticationException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpGet("{accountId:guid}")]
    public async Task<IActionResult> Logout(
        [Required] Guid accountId,
        CancellationToken cancellationToken = default)
    {
        //await authenticationService.InvalidateTokensAsync(accountId, cancellationToken);

        return Ok();
    }
}