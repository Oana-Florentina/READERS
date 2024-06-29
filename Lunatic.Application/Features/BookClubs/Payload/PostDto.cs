using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.BookClubs.Payload
{
    public class PostDto
    {
        public Guid PostId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public Guid BookClubId { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = default!;
        public string Text { get; set; } = default!;

    }
}
