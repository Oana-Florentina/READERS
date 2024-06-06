
using FluentValidation;
using Lunatic.Application.Features.Ratings.Commands.UpdateRating;
using Lunatic.Application.Persistence;


namespace Lunatic.Application.Features.Ratings.Commands.UpdateRating
{
    internal class UpdateRatingCommandValidator : AbstractValidator<UpdateRatingCommand>
    {
        private readonly IRatingRepository ratingRepository;
        private readonly IBookRepository bookRepository;
        private readonly IUserRepository userRepository;


        public UpdateRatingCommandValidator(IRatingRepository ratingRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            this.ratingRepository = ratingRepository;
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;


            DateTime dateTime = DateTime.Now;

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

            RuleFor(request => request.CommentMessage)
                  .NotEmpty().WithMessage("{PropertyName} is required.")
                  .NotNull().WithMessage("{PropertyName} is required.")
                  .MaximumLength(500).WithMessage("{PropertyName} must be less than 500 characters.");

            RuleFor(request => request.Score)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .InclusiveBetween(1, 10).WithMessage("{PropertyName} must be between 1 and 10.");


        }
    }
}
