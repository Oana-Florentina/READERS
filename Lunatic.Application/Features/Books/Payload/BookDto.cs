using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Books.Payload
{
    public class BookDto
    {
        
        public Guid BookId { get; set; } = default!;
        public string Title { get;  set; } = default!;
        public string Author { get;  set; } = default!;
        public string Genre { get;  set; } = default!;
        public int Year { get;  set; } = default!;
        public string Description { get;  set; } = default!;
    }
}
