using Lunatic.Application.Features.Readers.Mapper;
using Lunatic.Application.Features.Readers.Payload;
using Lunatic.Application.Features.Users.Queries.GetReadersByUserId;
using Lunatic.Application.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetReadersByUserId
{
    public class GetReadersByUserIdQueryHandler : IRequestHandler<GetReadersByUserIdQuery, GetReadersByUserIdQueryResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IReaderRepository readerRepository;

        public GetReadersByUserIdQueryHandler(IUserRepository userRepository, IReaderRepository readerRepository)
        {
            this.userRepository = userRepository;
            this.readerRepository = readerRepository;
        }

        public async Task<GetReadersByUserIdQueryResponse> Handle(GetReadersByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Fetch the user by Id
            var userResult = await userRepository.FindByIdAsync(request.UserId);

            if (!userResult.IsSuccess || userResult.Value == null)
            {
                return new GetReadersByUserIdQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            var user = userResult.Value;
            var readerIds = user.ReaderIds;

            if (readerIds == null || !readerIds.Any())
            {
                return new GetReadersByUserIdQueryResponse
                {
                    Success = true, // Success but empty list
                    Readers = new List<ReaderDto>()
                };
            }

            // Fetch reader details for each reader ID
            var readers = new List<ReaderDto>();
            foreach (var readerId in readerIds)
            {
                var readerResult = await readerRepository.FindByIdAsync(readerId);
                if (readerResult.IsSuccess && readerResult.Value != null)
                {
                    readers.Add(ReaderMapper.MapToReaderDto(readerResult.Value));
                }
                else
                {
                    // Optionally handle reader fetch failure, log or continue without this reader
                }
            }

            return new GetReadersByUserIdQueryResponse
            {
                Success = true,
                Readers = readers
            };
        }
    }
}
