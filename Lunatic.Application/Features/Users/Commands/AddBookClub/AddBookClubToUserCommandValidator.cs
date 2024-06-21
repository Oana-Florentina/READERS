using Lunatic.Application.Persistence;
using FluentValidation;


namespace Lunatic.Application.Features.Users.Commands.AddBookClub
{
    public class AddBookClubToUserCommandValidator : AbstractValidator<AddBookClubToUserCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IBookClubRepository bookClubRepository;
        public AddBookClubToUserCommandValidator(IUserRepository userRepository, IBookClubRepository bookClubRepository)
        {
            this.userRepository = userRepository;
            this.bookClubRepository = bookClubRepository;

            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (userId, cancellationToken) => await this.userRepository.ExistsByIdAsync(userId))
                .WithMessage("{PropertyName} must exist.");

            RuleFor(request => request.BookClubId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} is required.")
               .MustAsync(async (bookClubId, cancellationToken) => await this.bookClubRepository.ExistsByIdAsync(bookClubId))
               .WithMessage("{PropertyName} must exists.");
               


            RuleFor(request => new { request.UserId, request.BookClubId })
              .MustAsync(async (req, cancellationToken) => {
                  var user = (await this.userRepository.FindByIdAsync(req.UserId)).Value;
                  return !user.BookClubIds.Contains(req.BookClubId);
              })
              .WithMessage("User must not include BookClubId.");

            ClassLevelCascadeMode = CascadeMode.Stop;

        }
    }
}
