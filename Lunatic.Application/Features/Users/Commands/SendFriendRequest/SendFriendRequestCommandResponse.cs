using Lunatic.Application.Features.Users.Payload;
using Lunatic.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.SendFriendRequest
{
    public class SendFriendRequestCommandResponse : ResponseBase
    {
        public SendFriendRequestCommandResponse() : base() { }

        public FriendRequestDto FriendRequest { get; set; } = default!;
    }
    
}
