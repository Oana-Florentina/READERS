using Lunatic.Application.Features.Posts.Queries.GetPostById;
using Lunatic.Application.Features.Users.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Lunatic.API.Controllers
{
    public class PostController :ApiControllerBase
    {
        [HttpGet("{postId}")]
        [Produces("application/json")]
        [ProducesResponseType<GetPostByIdQueryResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<GetPostByIdQueryResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid postId)
        {
            var result = await Mediator.Send(new GetPostByIdQuery(postId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
