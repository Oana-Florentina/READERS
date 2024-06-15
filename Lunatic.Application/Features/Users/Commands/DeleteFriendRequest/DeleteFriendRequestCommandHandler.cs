using Lunatic.Application.Features.FriendRequests.Commands.DeleteFriendRequest;
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

        public DeleteFriendRequestCommandHandler(IFriendRequestRepository friendRequestRepository)
        {
            this.friendRequestRepository = friendRequestRepository;
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
            return new DeleteFriendRequestCommandResponse
            {
                Success = true
            };
        }
    }
}
