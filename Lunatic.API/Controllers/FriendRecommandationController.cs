using Lunatic.Application.Features.Books.Commands.CreateBook;
using Lunatic.Application.Features.Books.Queries.GetAll;
using Lunatic.Application.Features.Books.Queries.GetById;
using Lunatic.Application.Features.Users.Commands.SendFriendRecommandation;
using Lunatic.Application.Features.Users.Queries.GetFriendRecommandationByReceiverId;
using Microsoft.AspNetCore.Mvc;

namespace Lunatic.API.Controllers
{
    public class FriendRecommandationController : ApiControllerBase
    {
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType<SendFriendRecommandationCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<SendFriendRecommandationCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(SendFriendRecommandationCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{receiverId}")]
        [Produces("application/json")]
        [ProducesResponseType<GetFriendRecommandationByReceiverIdQueryResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<GetFriendRecommandationByReceiverIdQueryResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid receiverId)
        {
            var result = await Mediator.Send(new GetFriendRecommandationByReceiverIdQuery(receiverId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /*[HttpGet]
        [Produces("application/json")]
        [ProducesResponseType<GetAllBooksQueryResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllBooksQuery());
            return Ok(result.Books);
        }*/
    }
}
