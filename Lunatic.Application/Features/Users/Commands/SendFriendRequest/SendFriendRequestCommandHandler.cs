
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.Users.Payload;
using MediatR;
using Lunatic.Application.Features.Users.Commands.SendFriendRequest;
using Lunatic.Application.Features.FriendRequests.Commands.CreateFriendRequest;
using Lunatic.Application.Features.Ratings.Commands.CreateRating;
using Lunatic.Application.Features.Ratings.Mapper;
using Lunatic.Application.Features.Users.Mapper;
using Lunatic.Application.Features.Users.Commands.AddReader;
using Lunatic.Application.Features.Users.Commands.CreateUser;


namespace Lunatic.Application.Features.FriendRequests.Commands.SendFriendRequest
{
    public class SendFriendRequestCommandHandler : IRequestHandler<SendFriendRequestCommand, SendFriendRequestCommandResponse>
    {
        private readonly IFriendRequestRepository friendRequestRepository;
        private readonly IUserRepository userRepository;

        public SendFriendRequestCommandHandler(IFriendRequestRepository friendRequestRepository, IUserRepository userRepository)
        {
            this.friendRequestRepository = friendRequestRepository;
            this.userRepository = userRepository;
        }

        public async Task<SendFriendRequestCommandResponse> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new SendFriendRequestCommandValidator(this.friendRequestRepository, this.userRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new SendFriendRequestCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            var userResult = await this.userRepository.FindByIdAsync(request.ReceiverId);
         

            var friendRequest = new FriendRequest(
                 request.SenderId,
                 request.ReceiverId,
                 request.Status
             );

            await this.friendRequestRepository.AddAsync(friendRequest);
            userResult.Value.AddFriendRequest(friendRequest.FriendRequestId);
            var dbUserResult = await this.userRepository.UpdateAsync(userResult.Value);
            return new SendFriendRequestCommandResponse
            {
                Success = true,
                FriendRequest = new FriendRequestDto
                {
                    FriendRequestId = friendRequest.FriendRequestId,
                    SenderId = friendRequest.SenderId,
                    ReceiverId = friendRequest.ReceiverId,
                    Status = friendRequest.Status

                }
            };

        }
    }
}
