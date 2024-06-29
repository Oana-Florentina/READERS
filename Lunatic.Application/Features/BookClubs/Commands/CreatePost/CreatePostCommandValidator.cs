using FluentValidation;
using Lunatic.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.BookClubs.Commands.CreatePost
{
    internal class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        private readonly IBookClubRepository bookClubRepository;
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;
        public CreatePostCommandValidator(IPostRepository postRepository, IUserRepository userRepository, IBookClubRepository bookClubRepository)
        {
            this.bookClubRepository = bookClubRepository;
            this.postRepository = postRepository;
            this.userRepository = userRepository;

            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (userId, cancellationToken) => await this.userRepository.ExistsByIdAsync(userId))
                .WithMessage("{PropertyName} must exist.");

            RuleFor(request => request.BookClubId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (bookClubId, cancellationToken) => await this.bookClubRepository.ExistsByIdAsync(bookClubId))
                .WithMessage("{PropertyName} must exist.");

            RuleFor(request => request.Text)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");


            ClassLevelCascadeMode = CascadeMode.Stop;
          
        }
    }
}
