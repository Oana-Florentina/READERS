using Lunatic.Application.Features.Books.Queries.GetAll;
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
            return Ok(result);
        }


    }
}

