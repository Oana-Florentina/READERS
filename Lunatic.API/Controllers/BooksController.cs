using Lunatic.Application.Features.Books.Commands.CreateBook;
using Lunatic.Application.Features.Books.Commands.DeleteBook;
using Lunatic.Application.Features.Books.Queries.GetAll;
using Lunatic.Application.Features.Books.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Lunatic.API.Controllers
{
    public class BooksController : ApiControllerBase
    {
  

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType<GetAllBooksQueryResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllBooksQuery());
            return Ok(result.Books);
        }

        //create a new book
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType<CreateBookCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<CreateBookCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateBookCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{bookId}")]
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
        }

        [HttpDelete("{bookId}")]
        [Produces("application/json")]
        [ProducesResponseType<DeleteBookCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DeleteBookCommandResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid bookId)
        {
            var deleteBookCommand = new DeleteBookCommand() { BookId = bookId };
            var result = await Mediator.Send(deleteBookCommand);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }


    }
}

