using MediatR;
using System;

namespace Lunatic.Application.Features.Users.Queries.GetWantToRead
{
    public record GetWantToReadQuery(Guid UserId) : IRequest<GetWantToReadQueryResponse>;
}
