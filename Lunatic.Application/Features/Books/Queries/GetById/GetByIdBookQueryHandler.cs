
using Lunatic.Application.Persistence;
using MediatR;
using Lunatic.Application.Features.Books.Mapper;





namespace Lunatic.Application.Features.Books.Queries.GetById
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, GetByIdBookQueryResponse>
    {
        private readonly IBookRepository bookRepository;

        public GetByIdBookQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<GetByIdBookQueryResponse> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
        {
            GetByIdBookQueryResponse response = new GetByIdBookQueryResponse();
            var bookResult = await this.bookRepository.FindByIdAsync(request.BookId);

            if (!bookResult.IsSuccess)
            {
                return new GetByIdBookQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "Book not found" }
                };
            }

            return new GetByIdBookQueryResponse
            {
                Success = true,
                Book = BookMapper.MapToBookDto(bookResult.Value)
            };
        }

       
    }
}
