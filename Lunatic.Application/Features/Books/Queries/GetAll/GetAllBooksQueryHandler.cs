using Lunatic.Application.Features.Books.Payload;
using Lunatic.Application.Features.Books.Queries.GetAll;
using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Books.Queries.GetAll
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, GetAllBooksQueryResponse>
    {
        private readonly IBookRepository bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<GetAllBooksQueryResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            GetAllBooksQueryResponse response = new GetAllBooksQueryResponse();
            var books = await this.bookRepository.GetAllAsync();

            if (books.IsSuccess)
            {
                response.Books = books.Value.Select(book => new BookDto
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    Description = book.Description,
                    Year = book.Year,
                }).ToList();
            }
            return response;
        }
    }
}
