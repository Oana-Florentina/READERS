using Lunatic.UI.Payload;

namespace Lunatic.UI.Services.Responses
{
    public class AddReaderResponse : Response
    {
        public ReaderDto Reader { get; set; } = default!;
    }
}
