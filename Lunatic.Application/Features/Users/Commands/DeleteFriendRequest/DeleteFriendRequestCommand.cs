using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.DeleteFriendRequest
{
    public class DeleteFriendRequestCommand:IRequest<DeleteFriendRequestCommandResponse>
    {
        public Guid RequestId { get; set; } 
        
        public bool Status { get; set; }
    }
}
