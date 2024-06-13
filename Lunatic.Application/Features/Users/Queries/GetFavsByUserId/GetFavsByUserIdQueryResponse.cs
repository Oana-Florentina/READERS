using Lunatic.Application.Responses;
using Lunatic.Application.Features.Books.Payload;

namespace Lunatic.Application.Features.Users.Queries.GetFavsByUserId
{
    public class GetFavsByUserIdQueryResponse : ResponseBase
    {
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
