using System.ComponentModel.DataAnnotations;
using Application.Domain.Accounts.Commands.CreateAccount;
using Application.Dtos.Accounts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReptiloidTwitter.Common;

namespace ReptiloidTwitter.Controllers;

[Route("api/[controller]/[action]")]
public class AccountController(IMediator mediator, IMapper mapper) : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [Required] CreateAccountDto model,
        CancellationToken cancellationToken = default)
    {
        var command = mapper.Map<CreateAccountCommand>(model);
        var response = await mediator.Send(command, cancellationToken);
        
        return Ok(response);
    }
}