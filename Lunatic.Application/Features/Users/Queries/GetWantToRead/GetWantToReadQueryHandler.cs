using Lunatic.Application.Features.Books.Mapper;
using Lunatic.Application.Features.Books.Queries.GetById;
using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetWantToRead
{
    public class GetWantToReadQueryHandler : IRequestHandler<GetWantToReadQuery, GetWantToReadkQueryResponse>
    {
        private readonly IBookRepository bookRepository;

        public GetWantToReadQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<GetWantToReadQueryResponse> Handle(GetWantToReadQuery request, CancellationToken cancellationToken)
        {
            GetWantToReadQueryResponse response = new GetWantToReadQueryResponse();
            var bookResult = await this.bookRepository.FindByIdAsync(request.BookId);

            if (!bookResult.IsSuccess)
            {
                return new GetWantToReadQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "Book not found" }
                };
            }

            return new GetWantToReadQueryResponse
            {
                Success = true,
                Book = BookMapper.MapToBookDto(bookResult.Value)
            };
        }


    }
}
