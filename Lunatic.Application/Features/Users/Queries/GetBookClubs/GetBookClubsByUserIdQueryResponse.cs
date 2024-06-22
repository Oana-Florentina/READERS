using Lunatic.Application.Responses;
using Lunatic.Application.Features.BookClubs.Payload;

namespace Lunatic.Application.Features.Users.Queries.GetBookClubs
{
   
    public class GetBookClubsByUserIdQueryResponse : ResponseBase
    {
        public List<BookClubDto> BookClubs { get; set; } = new List<BookClubDto>();
    }
}
