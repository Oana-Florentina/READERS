using Lunatic.Application.Features.Readers.Queries.GetAll;
using Lunatic.Application.Features.Users.Commands.AddWantToRead;
using Lunatic.Application.Features.Users.Commands.AddReader;
using Lunatic.Application.Features.Users.Commands.CreateUser;
using Lunatic.Application.Features.Users.Commands.DeleteUser;
using Lunatic.Application.Features.Users.Commands.UpdateUser;
using Lunatic.Application.Features.Users.Queries.GetAll;
using Lunatic.Application.Features.Users.Queries.GetById;
using Lunatic.Application.Features.Users.Queries.GetReadersByUserId;
using Lunatic.Application.Features.Users.Queries.GetWantToRead;
using Microsoft.AspNetCore.Mvc;

namespace Lunatic.API.Controllers {
	public class UsersController : ApiControllerBase {
		[HttpPost]
		[Produces("application/json")]
		[ProducesResponseType<CreateUserCommandResponse>(StatusCodes.Status201Created)]
		[ProducesResponseType<CreateUserCommandResponse>(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Create(CreateUserCommand command) {
			var result = await Mediator.Send(command);
			if (!result.Success) {
				return BadRequest(result);
			}
			return Ok(result);
		}

       

        [HttpPut("{userId}")]
		[Produces("application/json")]
		[ProducesResponseType<UpdateUserCommandResponse>(StatusCodes.Status200OK)]
		[ProducesResponseType<UpdateUserCommandResponse>(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(Guid userId, UpdateUserCommand command) {
			if (userId != command.UserId) {
				return BadRequest(new UpdateUserCommandResponse {
					Success = false,
					ValidationErrors = new List<string> { "The user Id Path and user Id Body must be equal." }
				});
			}

			var result = await Mediator.Send(command);
			if (!result.Success) {
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpDelete("{userId}")]
		[Produces("application/json")]
		[ProducesResponseType<DeleteUserCommandResponse>(StatusCodes.Status200OK)]
		[ProducesResponseType<DeleteUserCommandResponse>(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Delete(Guid userId) {
			var deleteUserCommand = new DeleteBookCommand() { UserId = userId };
			var result = await Mediator.Send(deleteUserCommand);
			if (!result.Success) {
				return NotFound(result);
			}
			return Ok(result);
		}
		
		[HttpGet("{userId}")]
		[Produces("application/json")]
		[ProducesResponseType<GetByIdUserQueryResponse>(StatusCodes.Status200OK)]
		[ProducesResponseType<GetByIdUserQueryResponse>(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Get(Guid userId) {
			var result = await Mediator.Send(new GetByIdUserQuery(userId));
			if (!result.Success) {
				return NotFound(result);
			}
			return Ok(result);
		}

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType<GetAllUsersQueryResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllUsersQuery());
            return Ok(result.Users);
        }

        [HttpPost("{userId}/wantToRead")]
        [Produces("application/json")]
        [ProducesResponseType<AddWantToReadCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<AddWantToReadCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddWantToRead(Guid userId, Guid bookId)
        {
            var command = new AddWantToReadCommand
            {
                UserId = userId,
                BookId = bookId
            };
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{userId}/wantToRead")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetWantToReadQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetWantToReadQueryResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWantToRead(Guid userId)
        {
            var result = await Mediator.Send(new GetWantToReadQuery(userId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result.Books);
        }

        [HttpGet("{userId}/readers")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetReadersByUserIdQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetReadersByUserIdQueryResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReaders(Guid userId)
        {
            var result = await Mediator.Send(new GetReadersByUserIdQuery(userId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result.Readers);
        }

        [HttpPost("{userId}/readers")]
        [Produces("application/json")]
        [ProducesResponseType<AddReaderCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<AddReaderCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWantToRead(Guid userId, Guid readerId)
        {
            var command = new AddReaderCommand
            {
                UserId = userId,
                ReaderId = readerId
            };
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


    }
}

