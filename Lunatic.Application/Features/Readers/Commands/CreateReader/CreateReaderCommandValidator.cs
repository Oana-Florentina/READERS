
using Lunatic.Application.Persistence;
using FluentValidation;


namespace Lunatic.Application.Features.Readers.Commands.CreateReader
{
    internal class CreateReaderCommandValidator : AbstractValidator<CreateReaderCommand>
    {
        private readonly IReaderRepository readerRepository;

        public CreateReaderCommandValidator(IReaderRepository readerRepository)
        {
            this.readerRepository = readerRepository;
            DateTime dateTime = DateTime.Now;

            RuleFor(request => request.BookId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (bookId, cancellationToken) => await this.readerRepository.ExistsByIdAsync(bookId))
                .WithMessage("{PropertyName} must exists.");

            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (userId, cancellationToken) => await this.readerRepository.ExistsByIdAsync(userId))
                .WithMessage("{PropertyName} must exists.");

            RuleFor(request => request.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .LessThan(request => request.EndDate).WithMessage("{PropertyName} must be less than EndDate.")
                .LessThan(dateTime).WithMessage("{PropertyName} must be less than current date.");
                

            

            RuleFor(request => request.EndDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(request => request.StartDate)
                .WithMessage("{PropertyName} must be greater than StartDate.")
                .LessThan(dateTime).WithMessage("{PropertyName} must be less than current date.");


        }
    }
}
