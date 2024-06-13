using Lunatic.Application.Features.Readers.Mapper;
using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Readers.Queries.GetReaderByBookIdAndUserId
{
    public class GetReaderByBookIdAndUserIdQueryHandler : IRequestHandler<GetReaderByBookIdAndUserIdQuery, GetReaderByBookIdAndUserIdQueryResponse>
    {
        private readonly IReaderRepository readerRepository;

        public GetReaderByBookIdAndUserIdQueryHandler(IReaderRepository readerRepository)
        {
            this.readerRepository = readerRepository;
        }

        public async Task<GetReaderByBookIdAndUserIdQueryResponse> Handle(GetReaderByBookIdAndUserIdQuery request, CancellationToken cancellationToken)
        {
            var readerResult = await this.readerRepository.GetReaderByBookIdAndUserIdAsync(request.BookId, request.UserId);

            if (!readerResult.IsSuccess)
            {
                return new GetReaderByBookIdAndUserIdQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "Reader not found" }
                };
            }

            return new GetReaderByBookIdAndUserIdQueryResponse
            {
                Success = true,
                Reader = ReaderMapper.MapToReaderDto(readerResult.Value)
                
            };
        }
    }
}
