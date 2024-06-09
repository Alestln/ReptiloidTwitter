

using System.ComponentModel.DataAnnotations;
using Application.Domain.Photos.Queries.GetUserProfilePhotos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReptiloidTwitter.Common;

namespace ReptiloidTwitter.Controllers;

[Route("api/[controller]/[action]")]
public class PhotoController(IMediator mediator) : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> UserProfilePhotos(
        [Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetUserProfilePhotosQuery(id);
        var photos = await mediator.Send(query, cancellationToken);
        
        return Ok(photos);
    }
}