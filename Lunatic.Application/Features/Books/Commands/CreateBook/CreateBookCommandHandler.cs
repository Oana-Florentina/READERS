using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.Books.Payload;
using MediatR;



namespace Lunatic.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
    {
        private readonly IBookRepository bookRepository;
        private readonly ICoverRepository coverRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository, ICoverRepository  coverRepository)
        {
            this.bookRepository = bookRepository;
                        this.coverRepository = coverRepository;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateBookCommandValidator(this.bookRepository, this.coverRepository);
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
                    Cover = book.Cover,
                    Ratings = book.Ratings
                }
            };
        }
    }
}
