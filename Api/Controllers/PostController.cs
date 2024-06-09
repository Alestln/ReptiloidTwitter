using System.ComponentModel.DataAnnotations;
using Application.Domain.Posts.Queries.GetUserPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReptiloidTwitter.Common;

namespace ReptiloidTwitter.Controllers;

[Route("api/[controller]/[action]")]
public class PostController(IMediator mediator) : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPostsByUserId(
        [Required] Guid userProfileId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetUserPostsQuery(userProfileId);
        var posts = await mediator.Send(query, cancellationToken);
        
        return Ok(posts);
    }
}