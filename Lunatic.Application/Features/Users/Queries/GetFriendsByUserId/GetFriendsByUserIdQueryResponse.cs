using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunatic.Application.Responses;
using Lunatic.Application.Features.Users.Payload;

namespace Lunatic.Application.Features.Users.Queries.GetFriendsByUserId
{
    public class GetFriendsByUserIdQueryResponse : ResponseBase
    {
        public List<UserDto> UserFriends { get; set; } = new List<UserDto>();
    }
}
