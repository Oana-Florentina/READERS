using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Payload
{
    public class FriendRecommandationDto
    {
        public Guid FriendRecommandationId { get; set; } = default!;
        public Guid SenderId { get; set; } = default!;
        public Guid ReceiverId { get; set; } = default!;
        public Guid BookId { get; set; } = default!;
    }
}
