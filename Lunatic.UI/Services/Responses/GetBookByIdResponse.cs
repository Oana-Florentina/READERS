using Lunatic.UI.Payload;

namespace Lunatic.UI.Services.Responses
{
    public class GetBookByIdResponse : Response
    {
        public BookDto Book { get; set; } = default!;
    }
}
