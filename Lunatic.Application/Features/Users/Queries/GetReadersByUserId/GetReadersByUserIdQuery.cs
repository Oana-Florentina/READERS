using MediatR;
using System;

namespace Lunatic.Application.Features.Users.Queries.GetReadersByUserId
{
    public record GetReadersByUserIdQuery(Guid UserId) : IRequest<GetReadersByUserIdQueryResponse>;
}
