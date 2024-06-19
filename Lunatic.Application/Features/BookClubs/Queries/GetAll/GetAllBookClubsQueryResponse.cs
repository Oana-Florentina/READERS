using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunatic.Application.Features.BookClubs.Payload;

namespace Lunatic.Application.Features.BookClubs.Queries.GetAll
{
    public class GetAllBookClubsQueryResponse
    {
        public List<BookClubDto> BookClubs { get; set; } = default!;
    }
}
