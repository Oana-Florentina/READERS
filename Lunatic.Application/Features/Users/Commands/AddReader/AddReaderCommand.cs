using MediatR;


namespace Lunatic.Application.Features.Users.Commands.AddReader
{
    public class AddReaderCommand : IRequest<AddReaderCommandResponse>
    {
        public Guid UserId { get; set; } = default!;
        public Guid ReaderId { get; set; } = default!;
    }
}
