using FluentValidation;
using Lunatic.Application.Features.Users.Commands.SendFriendRecommandation;
using Lunatic.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.SendFriendRecommandation
{

    internal class SendFriendRecommandationCommandValidator : AbstractValidator<SendFriendRecommandationCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IFriendRecommandationRepository friendRecommandationRepository;
        private readonly IBookRepository bookRepository;



        public SendFriendRecommandationCommandValidator(IFriendRecommandationRepository friendRecommandationRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            this.userRepository = userRepository;
            this.friendRecommandationRepository = friendRecommandationRepository;
            this.bookRepository = bookRepository;

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

            RuleFor(request => request.BookId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (bookId, cancellationToken) => await this.bookRepository.ExistsByIdAsync(bookId))
                .WithMessage("{PropertyName} must exist.");

            ClassLevelCascadeMode = CascadeMode.Stop;

        }
    }
}
