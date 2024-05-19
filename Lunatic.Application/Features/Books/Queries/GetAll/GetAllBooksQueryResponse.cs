using Lunatic.Application.Features.Books.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Books.Queries.GetAll
{
    public class GetAllBooksQueryResponse
    {
        public List<BookDto> Books { get; set; } = default!;
    }
}
