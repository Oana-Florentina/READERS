
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.Users.Payload;
using MediatR;
using Lunatic.Application.Features.Users.Commands.SendFriendRecommandation;
using Lunatic.Application.Features.Ratings.Commands.CreateRating;
using Lunatic.Application.Features.Ratings.Mapper;
using Lunatic.Application.Features.Users.Mapper;
using Lunatic.Application.Features.Users.Commands.AddReader;
using Lunatic.Application.Features.Users.Commands.CreateUser;


namespace Lunatic.Application.Features.FriendRecommandations.Commands.SendFriendRecommandation
{
    public class SendFriendRecommandationCommandHandler : IRequestHandler<SendFriendRecommandationCommand, SendFriendRecommandationCommandResponse>
    {
        private readonly IFriendRecommandationRepository friendRecommandationRepository;
        private readonly IUserRepository userRepository;
        private readonly IBookRepository bookRepository;

        public SendFriendRecommandationCommandHandler(IFriendRecommandationRepository friendRecommandationRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            this.friendRecommandationRepository = friendRecommandationRepository;
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
        }

        public async Task<SendFriendRecommandationCommandResponse> Handle(SendFriendRecommandationCommand request, CancellationToken cancellationToken)
        {
            var validator = new SendFriendRecommandationCommandValidator(this.friendRecommandationRepository, this.userRepository, this.bookRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new SendFriendRecommandationCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            var userResult = await this.userRepository.FindByIdAsync(request.ReceiverId);


            var friendRecommandation = new FriendRecommandation(
                 request.SenderId,
                 request.ReceiverId,
                 request.BookId
             );

            await this.friendRecommandationRepository.AddAsync(friendRecommandation);
            return new SendFriendRecommandationCommandResponse
            {
                Success = true,
                FriendRecommandation = new FriendRecommandationDto
                {
                    FriendRecommandationId = friendRecommandation.FriendRecommandationId,
                    SenderId = friendRecommandation.SenderId,
                    ReceiverId = friendRecommandation.ReceiverId,
                    BookId = friendRecommandation.BookId

                }
            };

        }
    }
}
