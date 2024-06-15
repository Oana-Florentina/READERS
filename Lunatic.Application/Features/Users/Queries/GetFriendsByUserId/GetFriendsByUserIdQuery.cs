using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetFriendsByUserId
{
    public record GetFriendsByUserIdQuery(Guid UserId) :IRequest<GetFriendsByUserIdQueryResponse>;
}
