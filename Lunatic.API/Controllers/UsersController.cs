using Lunatic.Application.Features.Readers.Queries.GetAll;
using Lunatic.Application.Features.Users.Commands.AddWantToRead;
using Lunatic.Application.Features.Users.Commands.AddReader;
using Lunatic.Application.Features.Users.Commands.CreateUser;
using Lunatic.Application.Features.Users.Commands.DeleteUser;
using Lunatic.Application.Features.Users.Commands.UpdateUser;
using Lunatic.Application.Features.Users.Queries.GetAll;
using Lunatic.Application.Features.Users.Queries.GetById;
using Lunatic.Application.Features.Users.Queries.GetReadersByUserId;
using Lunatic.Application.Features.Users.Queries.GetFavsByUserId;
using Lunatic.Application.Features.Users.Queries.GetWantToRead;
using Microsoft.AspNetCore.Mvc;
using Lunatic.Application.Features.Projects.Commands.UpdateProjectTasksSection;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.Users.Commands.AddFavorite;
using Lunatic.Application.Features.Users.Commands.SendFriendRequest;
using Lunatic.Application.Features.Users.Queries.GetFriendsRequests;
using Lunatic.Application.Features.Users.Commands.DeleteFriendRequest;
using Lunatic.Application.Features.Users.Queries.GetFriendsByUserId;
using Lunatic.Application.Features.Users.Commands.AddBookClub;
using Lunatic.Application.Features.Users.Queries.GetBookClubs;

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
			var deleteUserCommand = new DeleteUserCommand() { UserId = userId };
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
        public async Task<IActionResult> AddWantToRead(Guid userId, AddWantToReadCommand command)
        {
            if (userId != command.UserId)
            {
                return BadRequest(new AddWantToReadCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "The user Id Path and user Id Body must be equal." }
                });
            }
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
        [HttpGet("{userId}/favorites")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetFavsByUserIdQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetFavsByUserIdQueryResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsersFavs(Guid userId)
        {
            var result = await Mediator.Send(new GetFavsByUserIdQuery(userId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result.Books);
        }

        [HttpPost("{userId}/favorites")]
        [Produces("application/json")]
        [ProducesResponseType<AddFavoriteCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<AddFavoriteCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddFavorite(Guid userId, AddFavoriteCommand command)
        {
            if (userId != command.UserId)
            {
                return BadRequest(new AddFavoriteCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "The user Id Path and user Id Body must be equal." }
                });
            }
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
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
        public async Task<IActionResult> AddReaderToUser(Guid userId, AddReaderCommand command)
        {
            if (userId != command.UserId)
            {
                return BadRequest(new AddReaderCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "The user Id Path and user Id Body must be equal." }
                });
            }
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("{userId}/sendFriendRequest")]
        [Produces("application/json")]
        [ProducesResponseType<SendFriendRequestCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<SendFriendRequestCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendFriendRequest(Guid userId, SendFriendRequestCommand command)
        {
            if (userId != command.SenderId)
            {
                return BadRequest(new SendFriendRequestCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "The user Id Path and user Id Body must be equal." }
                });
            }
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{userId}/getFriendRequest")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetFriendsRequestsQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetFriendsRequestsQueryResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFriendsRequests(Guid userId)
        {
            var result = await Mediator.Send(new GetFriendsRequestsQuery(userId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result.FriendRequest);
        }

        [HttpDelete("FriendRequest/{requestId}")]
        [Produces("application/json")]
        [ProducesResponseType<DeleteFriendRequestCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DeleteFriendRequestCommandResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFriendRequest(Guid requestId, bool status)
        {
            var command = new DeleteFriendRequestCommand
            {
                RequestId = requestId,
                Status = status
            };

            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{userId}/friends")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetFriendsByUserIdQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetFriendsByUserIdQueryResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsersFriends(Guid userId)
        {
            var result = await Mediator.Send(new GetFriendsByUserIdQuery(userId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result.UserFriends);
        }

        [HttpPost("{userId}/bookClub")]
        [Produces("application/json")]
        [ProducesResponseType<AddBookClubToUserCommandResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<AddBookClubToUserCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBookClubToUser(Guid userId, AddBookClubToUserCommand command)
        {
            if (userId != command.UserId)
            {
                return BadRequest(new AddBookClubToUserCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "The user Id Path and user Id Body must be equal." }
                });
            }
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{userId}/bookClubs")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetBookClubsByUserIdQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetBookClubsByUserIdQueryResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsersBookClubs(Guid userId)
        {
            var result = await Mediator.Send(new GetBookClubsByUserIdQuery(userId));
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result.BookClubs);
        }
    }
}

