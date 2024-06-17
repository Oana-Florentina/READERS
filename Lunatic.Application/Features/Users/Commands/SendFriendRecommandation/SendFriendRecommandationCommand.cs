using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.SendFriendRecommandation
{
    public class SendFriendRecommandationCommand: IRequest <SendFriendRecommandationCommandResponse>
    {
        public Guid FriendRecommandationId { get; set; }
        public Guid SenderId { get;  set; } 
        public Guid ReceiverId { get;  set; }
        public Guid BookId { get;  set; }
    } 
}
