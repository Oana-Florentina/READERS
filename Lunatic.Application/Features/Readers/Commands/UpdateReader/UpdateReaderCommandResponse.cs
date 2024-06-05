
using Lunatic.Application.Features.Readers.Payload;
using Lunatic.Application.Responses;


namespace Lunatic.Application.Features.Readers.Commands.UpdateReader
{
    public class UpdateReaderCommandResponse : ResponseBase
    {
        public UpdateReaderCommandResponse() : base() 
        {

        }
        public ReaderDto Reader { get; set; } = default!;
    }
}
