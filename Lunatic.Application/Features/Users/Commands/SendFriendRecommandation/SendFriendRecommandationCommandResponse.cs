using Lunatic.Application.Features.Users.Payload;
using Lunatic.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.SendFriendRecommandation
{
    public class SendFriendRecommandationCommandResponse : ResponseBase
    {
        public SendFriendRecommandationCommandResponse() : base() { }

        public FriendRecommandationDto FriendRecommandation { get; set; } = default!;
    }
}
