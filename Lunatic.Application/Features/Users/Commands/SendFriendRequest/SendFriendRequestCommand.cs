using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.SendFriendRequest
{
    public class SendFriendRequestCommand: IRequest <SendFriendRequestCommandResponse>
    {
        public Guid FriendRequestId { get; set; }
        public Guid SenderId { get;  set; }
        public Guid ReceiverId { get;  set; }
        public bool Status { get;  set; }
    }
}
