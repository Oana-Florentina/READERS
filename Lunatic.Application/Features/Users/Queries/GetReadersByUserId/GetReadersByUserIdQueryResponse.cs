using Lunatic.Application.Responses;
using Lunatic.Application.Features.Readers.Payload;

namespace Lunatic.Application.Features.Users.Queries.GetReadersByUserId
{
    public class GetReadersByUserIdQueryResponse : ResponseBase
    {
        public List<ReaderDto> Readers { get; set; } = new List<ReaderDto>();
    }
}
