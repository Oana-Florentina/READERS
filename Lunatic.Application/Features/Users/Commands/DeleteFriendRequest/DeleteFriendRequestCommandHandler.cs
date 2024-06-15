using Lunatic.Application.Features.FriendRequests.Commands.DeleteFriendRequest;
using Lunatic.Application.Features.Users.Commands.AddFavorite;
using Lunatic.Application.Features.Users.Commands.DeleteFriendRequest;
using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.FriendRequests.Commands.DeleteFriendRequest
{
    
    public class DeleteFriendRequestCommandHandler : IRequestHandler<DeleteFriendRequestCommand, DeleteFriendRequestCommandResponse>
    {
        private readonly IFriendRequestRepository friendRequestRepository;
        private readonly IUserRepository userRepository;

        public DeleteFriendRequestCommandHandler(IFriendRequestRepository friendRequestRepository, IUserRepository userRepository)
        {
            this.friendRequestRepository = friendRequestRepository;
            this.userRepository = userRepository;
        }

        public async Task<DeleteFriendRequestCommandResponse> Handle(DeleteFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await this.friendRequestRepository.DeleteAsync(request.RequestId);

            if (!result.IsSuccess)
            {
                return new DeleteFriendRequestCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };

            }
            var senderId = result.Value.SenderId;
            var receiverId = result.Value.ReceiverId;
            var userResult = await this.userRepository.FindByIdAsync(senderId);
            var userResult2 = await this.userRepository.FindByIdAsync(receiverId);
            if (!userResult.IsSuccess)
            {
                return new DeleteFriendRequestCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            userResult.Value.DeleteFriendRequest(receiverId, request.Status);
            userResult2.Value.DeleteFriendRequest(senderId, request.Status);

            userResult2.Value.RemoveFriendRequest(request.RequestId);
            var dbUserResult = await this.userRepository.UpdateAsync(userResult.Value);
            var dbUserResult2 = await this.userRepository.UpdateAsync(userResult2.Value);
            var dbFriendRequestResult = await this.friendRequestRepository.DeleteAsync(request.RequestId);

            return new DeleteFriendRequestCommandResponse
            {
                Success = true
            };
        }
    }
}
