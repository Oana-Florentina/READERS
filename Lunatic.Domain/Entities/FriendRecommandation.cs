using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Domain.Entities
{
    public class FriendRecommandation
    {
        public FriendRecommandation(Guid senderId, Guid receiverId, Guid bookId)
        {
            FriendRecommandationId = Guid.NewGuid();
            SenderId = senderId;
            ReceiverId = receiverId;
            BookId = bookId;
            CreatedDate = DateTime.UtcNow;
        }
        public Guid FriendRecommandationId { get; private set; }
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public Guid BookId { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }

}
