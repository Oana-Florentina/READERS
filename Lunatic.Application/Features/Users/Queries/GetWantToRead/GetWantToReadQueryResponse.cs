using Lunatic.Application.Features.Books.Payload;
using Lunatic.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetWantToRead
{
    internal class GetWantToReadQueryResponse : ResponseBase
    {
        public GetWantToReadQueryResponse() : base() { }

        public BookDto Book { get; set; } = default!;
    }
}
