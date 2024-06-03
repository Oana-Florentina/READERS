using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.Books.Payload;
using MediatR;
using Lunatic.Application.Features.Books.Queries.GetAll;
using Lunatic.Application.Features.Users.Commands.CreateUser;
using Lunatic.Application.Features.Users.Payload;


namespace Lunatic.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
    {
        private readonly IBookRepository bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateBookCommandValidator(this.bookRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateBookCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var book = new Book(request.Title, request.Author, request.Year, request.Description, request.Cover);
            await this.bookRepository.AddAsync(book);

            return new CreateBookCommandResponse
            {
                Success = true,
                Book = new BookDto
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Year = book.Year,
                    Genres = book.Genres,
                    Ratings = book.Ratings
                }
            };
        }
    }
}
