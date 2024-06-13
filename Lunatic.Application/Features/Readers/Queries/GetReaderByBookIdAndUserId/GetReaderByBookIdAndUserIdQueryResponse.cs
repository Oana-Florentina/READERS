using Lunatic.Application.Responses;
using Lunatic.Application.Features.Readers.Payload;
using Lunatic.Domain.Entities;
using System;

namespace Lunatic.Application.Features.Readers.Queries.GetReaderByBookIdAndUserId
{
    public class GetReaderByBookIdAndUserIdQueryResponse : ResponseBase
    {
        public ReaderDto Reader { get; set; } = default!;
    }
}
