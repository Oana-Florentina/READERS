
using Lunatic.Application.Persistence;
using FluentValidation;


namespace Lunatic.Application.Features.Books.Commands.CreateBook
{
    internal class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private readonly IBookRepository bookRepository;

        public CreateBookCommandValidator(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(200).WithMessage("Author must not exceed 200 characters.");
            RuleFor(x => x.Year)
                .NotEmpty().WithMessage("Year is required.")
                .InclusiveBetween(0, 2100).WithMessage("Year must be between 0 and 2100.");
          
            RuleFor(x => x.Cover)
                .NotEmpty().WithMessage("Cover is required.");

            ClassLevelCascadeMode = CascadeMode.Stop;

        }
    }
}
