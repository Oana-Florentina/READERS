using Lunatic.Application.Features.BookClubs.Commands;
using Lunatic.Application.Features.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace Lunatic.API.Controllers
{
    public class BookClubController : ApiControllerBase
    {
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType<CreateBookClubCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<CreateBookClubCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateBookClubCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


    }
}
