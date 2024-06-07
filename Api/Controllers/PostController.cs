using Microsoft.AspNetCore.Mvc;
using ReptiloidTwitter.Common;

namespace ReptiloidTwitter.Controllers;

[Route("api/[controller]/[action]")]
public class PostController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPostsByUserId()
    {
        return Ok();
    }
}