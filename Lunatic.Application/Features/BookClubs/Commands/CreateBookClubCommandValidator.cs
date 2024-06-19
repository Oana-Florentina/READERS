
using Lunatic.Application.Persistence;
using FluentValidation;


namespace Lunatic.Application.Features.BookClubs.Commands.CreateBookClub
{
    internal class CreateBookClubCommandValidator : AbstractValidator<CreateBookClubCommand>
    {
        private readonly IBookClubRepository bookClubRepository;

        public CreateBookClubCommandValidator(IBookClubRepository bookClubRepository)
        {
            this.bookClubRepository = bookClubRepository;

            

            RuleFor(request => request.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(async (title, cancellationToken) => !await this.bookClubRepository.ExistsByTitleAsync(title))
                .WithMessage("{PropertyName} exists already.");

            RuleFor(request => request.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            

            ClassLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
