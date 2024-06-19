using Lunatic.Application.Features.BookClubs.Commands;
using Lunatic.Application.Features.BookClubs.Commands.Update;
using Lunatic.Application.Features.BookClubs.Queries.GetAll;
using Lunatic.Application.Features.BookClubs.Queries.GetById;
using Lunatic.Application.Features.Books.Queries.GetAll;
using Lunatic.Application.Features.Books.Queries.GetById;
using Lunatic.Application.Features.Users.Commands.CreateUser;
using Lunatic.Application.Features.Users.Commands.UpdateUser;
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

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType<GetAllBookClubsQueryResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllBookClubsQuery());
            return Ok(result.BookClubs);
        }

        [HttpGet("{bookClubId}")]
        [Produces("application/json")]
        [ProducesResponseType<GetBookClubByIdQueryResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<GetBookClubByIdQueryResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid bookClubId)
        {
            var result = await Mediator.Send(new GetBookClubByIdQuery(bookClubId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpPut("{bookClubId}")]
        [Produces("application/json")]
        [ProducesResponseType<UpdateBookClubCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<UpdateBookClubCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid bookClubId, UpdateBookClubCommand command)
        {
            if (bookClubId != command.BookClub)
            {
                return BadRequest(new UpdateUserCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "The BookClub Id Path and BookClub Id Body must be equal." }
                });
            }

            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
