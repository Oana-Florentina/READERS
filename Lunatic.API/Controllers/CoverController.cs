using Lunatic.Application.Features.Cover.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Lunatic.API.Controllers
{
    public class CoverController : ApiControllerBase
    {
        //create a new book
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType<AddCoverCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<AddCoverCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AddCoverCommand command)
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
