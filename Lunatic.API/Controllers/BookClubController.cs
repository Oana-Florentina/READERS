﻿using Lunatic.Application.Features.BookClubs.Commands;
using Lunatic.Application.Features.BookClubs.Queries.GetAll;
using Lunatic.Application.Features.BookClubs.Queries.GetById;
using Lunatic.Application.Features.Books.Queries.GetAll;
using Lunatic.Application.Features.Books.Queries.GetById;
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


    }
}
