
using Lunatic.Application.Persistence;
using FluentValidation;
using Lunatic.Application.Features.Users.Commands.SendFriendRequest;


namespace Lunatic.Application.Features.FriendRequests.Commands.CreateFriendRequest
{
    internal class SendFriendRequestCommandValidator : AbstractValidator<SendFriendRequestCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IFriendRequestRepository friendRequestRepository;



        public SendFriendRequestCommandValidator(IFriendRequestRepository friendRequestRepository, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.friendRequestRepository = friendRequestRepository;

            RuleFor(request => request.SenderId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (senderId, cancellationToken) => await this.userRepository.ExistsByIdAsync(senderId))
                .WithMessage("{PropertyName} must exist.");

            RuleFor(request => request.ReceiverId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (receiverId, cancellationToken) => await this.userRepository.ExistsByIdAsync(receiverId))
                .WithMessage("{PropertyName} must exist.");

            ClassLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
