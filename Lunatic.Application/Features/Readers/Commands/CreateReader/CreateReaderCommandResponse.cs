
using Lunatic.Application.Responses;
using Lunatic.Application.Features.Readers.Payload;


namespace Lunatic.Application.Features.Readers.Commands.CreateReader
{
    public class CreateReaderCommandResponse : ResponseBase
    {
        public CreateReaderCommandResponse() : base() { }

        public ReaderDto Reader { get; set; } = default!;
    }
}
