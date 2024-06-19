using Lunatic.Application.Features.BookClubs.Commands.Update;
using Lunatic.Application.Persistence;
using FluentValidation;


namespace Lunatic.Application.Features.BookClubs.Commands.Update
{
    internal class UpdateBookClubCommandValidator : AbstractValidator<UpdateBookClubCommand>
    {
        private readonly IBookClubRepository bookClubRepository;

        public UpdateBookClubCommandValidator(IBookClubRepository bookClubRepository)
        {
            this.bookClubRepository = bookClubRepository;



            RuleFor(request => request.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                

            RuleFor(request => request.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            ClassLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
