using Lunatic.Application.Features.Users.Payload;
using Lunatic.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetFriendsRequests
{
    public class GetFriendsRequestsQueryResponse : ResponseBase
    {
        public List<FriendRequestDto> FriendRequest { get; set; } = new List<FriendRequestDto>();
    }
}
