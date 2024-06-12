using Lunatic.Application.Responses;
using Lunatic.Application.Features.Books.Payload;

namespace Lunatic.Application.Features.Users.Queries.GetWantToRead
{
    public class GetWantToReadQueryResponse : ResponseBase
    {
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
