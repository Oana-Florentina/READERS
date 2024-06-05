
using FluentValidation;
using Lunatic.Application.Features.Readers.Commands.UpdateReader;
using Lunatic.Application.Persistence;


namespace Lunatic.Application.Features.Readers.Commands.UpdateReader
{
    internal class UpdateReaderCommandValidator : AbstractValidator<UpdateReaderCommand>
    {
        private readonly IReaderRepository readerRepository;
        private readonly IBookRepository bookRepository;
        private readonly IUserRepository userRepository;


        public UpdateReaderCommandValidator(IReaderRepository readerRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            this.readerRepository = readerRepository;
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
