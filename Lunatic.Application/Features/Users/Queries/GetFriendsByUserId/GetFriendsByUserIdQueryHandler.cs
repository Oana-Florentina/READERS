using Lunatic.Application.Features.Users.Mapper;
using Lunatic.Application.Features.Users.Payload;
using Lunatic.Application.Features.Users.Queries.GetFriendsByUserId;
using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetFriendsByUserId
{
    internal class GetFriendsByUserIdQueryHandler : IRequestHandler<GetFriendsByUserIdQuery, GetFriendsByUserIdQueryResponse>
    {
        private readonly IUserRepository userRepository;

        public GetFriendsByUserIdQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<GetFriendsByUserIdQueryResponse> Handle(GetFriendsByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Fetch the user by Id
            var userResult = await userRepository.FindByIdAsync(request.UserId);

            if (!userResult.IsSuccess || userResult.Value == null)
            {
                return new GetFriendsByUserIdQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            var user = userResult.Value;
            var userFriends = user.FriendsIds;

            if (userFriends == null || !userFriends.Any())
            {
                return new GetFriendsByUserIdQueryResponse
                {
                    Success = true, // Success but empty list
                    UserFriends = new List<UserDto>()
                };
            }

            // Fetch book details for each book ID
            var friends = new List<UserDto>();
            foreach (var bookId in userFriends)
            {
                var friendResult = await userRepository.FindByIdAsync(bookId);
                if (friendResult.IsSuccess && friendResult.Value != null)
                {
                    friends.Add(UserMapper.MapToUserDto(friendResult.Value));
                }
               
            }

            return new GetFriendsByUserIdQueryResponse
            {
                Success = true,
                UserFriends = friends
            };
        }
    }
}
