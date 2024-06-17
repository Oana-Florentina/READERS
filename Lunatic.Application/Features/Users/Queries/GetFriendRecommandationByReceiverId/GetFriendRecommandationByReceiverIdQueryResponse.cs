using Lunatic.Application.Features.Users.Payload;
using System;
using Lunatic.Application.Responses;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetFriendRecommandationByReceiverId
{
    public class GetFriendRecommandationByReceiverIdQueryResponse : ResponseBase
    {
        public List<FriendRecommandationDto> FriendRecommandations { get; set; } = new List<FriendRecommandationDto>();
    }
}
