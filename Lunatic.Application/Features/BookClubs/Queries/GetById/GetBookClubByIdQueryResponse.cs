
using Lunatic.Application.Responses;
using Lunatic.Application.Features.BookClubs.Payload;


namespace Lunatic.Application.Features.BookClubs.Queries.GetById
{
    public class GetBookClubByIdQueryResponse : ResponseBase
    {
        public GetBookClubByIdQueryResponse() : base() { }

        public BookClubDto BookClub { get; set; } = default!;
    }
}

