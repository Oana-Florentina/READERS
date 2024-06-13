using Lunatic.Application.Features.Users.Payload;
using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Mapper
{
    public class FriendRequestMapper
    {
        public static FriendRequestDto MapToFriendRequestDto(FriendRequest friendRequest)
        {
            return new FriendRequestDto
            {
                FriendRequestId = friendRequest.FriendRequestId,
                SenderId = friendRequest.SenderId,
                ReceiverId = friendRequest.ReceiverId,
                Status = friendRequest.Status,
            };
        }
    }
}
