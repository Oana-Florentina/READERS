using Lunatic.Application.Features.Readers.Commands.CreateReader;
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
    }
}
