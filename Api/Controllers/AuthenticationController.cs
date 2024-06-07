using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using Application.Domain.Accounts.Commands.CreateAccount;
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
        [Required] CreateAccountDto model,
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

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            /*var authenticationResponse = authenticationService.Login(loginRequest);
            return Ok(authenticationResponse);*/

            return Ok();
        }
        catch (AuthenticationException ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}