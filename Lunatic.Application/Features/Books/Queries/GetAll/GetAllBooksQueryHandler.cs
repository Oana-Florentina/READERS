using Lunatic.Application.Features.Books.Payload;
using Lunatic.Application.Features.Books.Queries.GetAll;
using Lunatic.Application.Features.Books.Mapper;
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
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
                response.Books = books.Value.Select(book => BookMapper.MapToBookDto(book)).ToList();
            }
            return response;
        }
    }
}
