using Lunatic.UI.Payload;

namespace Lunatic.UI.Services.Responses
{
    public class GetBookClubByIdResponse : Response
    {
        public BookClubDto BookClub { get; set; } = default!;
    }
}
