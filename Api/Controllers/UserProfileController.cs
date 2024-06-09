using System.ComponentModel.DataAnnotations;
using Application.Domain.UserProfiles.Queries.GetUserProfileInfo;
using Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReptiloidTwitter.Common;

namespace ReptiloidTwitter.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
public class UserProfileController(IMediator mediator) : ApiControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInfo(
        [Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        
        try
        {
            var userProfile = await mediator.Send(new GetUserProfileInfoQuery(id), cancellationToken);
            
            return Ok(userProfile);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}