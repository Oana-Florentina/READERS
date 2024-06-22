using Lunatic.UI.Payload;

namespace Lunatic.UI.Services.Responses
{
    public class CreateBookClubResponse : Response
    {
        public BookClubDto BookClub { get; set; } = default!;
    }
}
