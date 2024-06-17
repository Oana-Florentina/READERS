using Lunatic.Application.Features.Ratings.Queries.GetAll;
using Lunatic.Application.Features.Readers.Commands.CreateReader;
using Lunatic.Application.Features.Readers.Commands.DeleteReader;
using Lunatic.Application.Features.Readers.Commands.UpdateReader;
using Lunatic.Application.Features.Readers.Queries.GetAll;
using Lunatic.Application.Features.Readers.Queries.GetReaderByBookIdAndUserId;
using Lunatic.Application.Features.Users.Commands.UpdateUser;
using Microsoft.AspNetCore.Mvc;

namespace Lunatic.API.Controllers
{
    public class ReaderController : ApiControllerBase
    {
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType<CreateReaderCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<CreateReaderCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateReaderCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("bybookanduser")]
        [Produces("application/json")]
        [ProducesResponseType<GetReaderByBookIdAndUserIdQueryResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<GetReaderByBookIdAndUserIdQueryResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReaderByBookIdAndUserId([FromQuery] Guid bookId, [FromQuery] Guid userId)
        {
            var query = new GetReaderByBookIdAndUserIdQuery { BookId = bookId, UserId = userId };
            var result = await Mediator.Send(query);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //delete

        [HttpDelete("{readerId}")]
        [Produces("application/json")]
        [ProducesResponseType<DeleteReaderCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DeleteReaderCommandResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid readerId)
        {
            var deleteReaderCommand = new DeleteReaderCommand() { ReaderId = readerId };
            var result = await Mediator.Send(deleteReaderCommand);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //update

        [HttpPut("{readerId}")]
        [Produces("application/json")]
        [ProducesResponseType<UpdateReaderCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<UpdateReaderCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid readerId, UpdateReaderCommand command)
        {
            if (readerId != command.ReaderId)
            {
                return BadRequest(new UpdateReaderCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "The reader Id Path and reader Id Body must be equal." }
                });
            }

            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType<GetAllReadersQueryResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllReadersQuery());
            return Ok(result.Readers);
        }

    }
}
