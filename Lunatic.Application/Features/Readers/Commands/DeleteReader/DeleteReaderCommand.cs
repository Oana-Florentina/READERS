
using MediatR;


namespace Lunatic.Application.Features.Readers.Commands.DeleteReader
{
    public class DeleteReaderCommand : IRequest<DeleteReaderCommandResponse>
    {
        public Guid ReaderId { get; set; }
    }
}
