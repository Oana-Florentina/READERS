using Lunatic.Application.Features.Ratings.Commands.CreateRating;
using Lunatic.Application.Features.Ratings.Commands.DeleteRating;
using Microsoft.AspNetCore.Mvc;

namespace Lunatic.API.Controllers
{
    public class RatingController : ApiControllerBase
    {


        /* [HttpGet]
         [Produces("application/json")]
         [ProducesResponseType<GetAllBooksQueryResponse>(StatusCodes.Status200OK)]
         public async Task<IActionResult> GetAll()
         {
             var result = await Mediator.Send(new GetAllBooksQuery());
             return Ok(result);
         }*/


        //create a new Rating
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType<CreateRatingCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<CreateRatingCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateRatingCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

       /* [HttpGet("{bookId}")]
        [Produces("application/json")]
        [ProducesResponseType<GetByIdBookQueryResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<GetByIdBookQueryResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid bookId)
        {
            var result = await Mediator.Send(new GetByIdBookQuery(bookId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }*/

        [HttpDelete("{ratingId}")]
        [Produces("application/json")]
        [ProducesResponseType<DeleteRatingCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DeleteRatingCommandResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid ratingId)
        {
            var deleteRatingCommand = new DeleteRatingCommand() { RatingId = ratingId };
            var result = await Mediator.Send(deleteRatingCommand);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }


    }
}

