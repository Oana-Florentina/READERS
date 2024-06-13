using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Domain.Entities
{
    public class FriendRequest
    {
        public FriendRequest(Guid senderId, Guid receiverId, bool status)
        {
            FriendRequestId = Guid.NewGuid();
            SenderId = senderId;
            ReceiverId = receiverId;
            Status = status;
            CreatedDate = DateTime.UtcNow;
        }
        public Guid FriendRequestId { get; private set; }
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public bool Status { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}
