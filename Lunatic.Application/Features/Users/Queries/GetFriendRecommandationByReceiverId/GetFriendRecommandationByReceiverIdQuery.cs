using Lunatic.Application.Features.Books.Queries.GetById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetFriendRecommandationByReceiverId
{
    public record GetFriendRecommandationByReceiverIdQuery(Guid ReceiverId) : IRequest<GetFriendRecommandationByReceiverIdQueryResponse>;
   
}
