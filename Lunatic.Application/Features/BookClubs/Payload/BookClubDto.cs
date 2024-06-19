using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.BookClubs.Payload
{
    public class BookClubDto
    {
        public Guid BookClubId { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<Guid> Books { get;  set; } = default!;
        public List<Guid> Members { get;  set; } = default!;

    }
}
