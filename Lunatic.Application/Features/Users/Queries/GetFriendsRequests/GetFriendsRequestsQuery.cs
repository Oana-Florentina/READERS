using Lunatic.Application.Features.Users.Queries.GetFavsByUserId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetFriendsRequests
{
    public record GetFriendsRequestsQuery(Guid UserId) : IRequest<GetFriendsRequestsQueryResponse>;
}
