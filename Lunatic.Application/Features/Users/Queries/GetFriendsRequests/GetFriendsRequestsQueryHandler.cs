using Lunatic.Application.Features.Users.Mapper;
using Lunatic.Application.Features.Users.Payload;
using Lunatic.Application.Features.Users.Queries.GetAll;
using Lunatic.Application.Features.Users.Queries.GetFriendsRequests;
using Lunatic.Application.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetFriendsRequests
{
    public class GetFriendsRequestsQueryHandler : IRequestHandler<GetFriendsRequestsQuery, GetFriendsRequestsQueryResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IFriendRequestRepository friendRequestRepository;

        public GetFriendsRequestsQueryHandler(IUserRepository userRepository, IFriendRequestRepository friendRequestRepository)
        {
            this.userRepository = userRepository;
            this.friendRequestRepository = friendRequestRepository;
        }

        public async Task<GetFriendsRequestsQueryResponse> Handle(GetFriendsRequestsQuery request, CancellationToken cancellationToken)
        {
            GetFriendsRequestsQueryResponse response = new GetFriendsRequestsQueryResponse();
            var friendRequests = await this.friendRequestRepository.GetAllAsync();
            Console.WriteLine($"senderId: {request.UserId}");
            Console.WriteLine($"receiverId: {friendRequests.Value}");

            if (friendRequests.IsSuccess)
            {

                response.FriendRequest = friendRequests.Value.Select(friendRequest => FriendRequestMapper.MapToFriendRequestDto(friendRequest)).ToList();
            }
            return response;
        }
    }
}
