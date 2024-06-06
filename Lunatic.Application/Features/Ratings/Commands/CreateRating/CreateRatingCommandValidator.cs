
using Lunatic.Application.Persistence;
using FluentValidation;


namespace Lunatic.Application.Features.Ratings.Commands.CreateRating
{
    internal class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
    {
        private readonly IRatingRepository ratingRepository;
        private readonly IBookRepository bookRepository;
        private readonly IUserRepository userRepository;


        public CreateRatingCommandValidator(IRatingRepository ratingRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            this.ratingRepository = ratingRepository;
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;


            DateTime dateTime = DateTime.Now;

           
            RuleFor(request => request.CommentMessage)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must be less than 500 characters.");

            RuleFor(request => request.Score)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .InclusiveBetween(1, 10).WithMessage("{PropertyName} must be between 1 and 10.");

            RuleFor(request => request.BookId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (bookId, cancellationToken) => await this.bookRepository.ExistsByIdAsync(bookId))
                .WithMessage("{PropertyName} must exists.");

            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (userId, cancellationToken) => await this.userRepository.ExistsByIdAsync(userId))
                .WithMessage("{PropertyName} must exists.");

           


        }
    }
}
