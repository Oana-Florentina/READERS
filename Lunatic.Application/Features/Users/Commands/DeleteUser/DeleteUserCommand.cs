
using MediatR;


namespace Lunatic.Application.Features.Users.Commands.DeleteUser {
    public class DeleteBookCommand : IRequest<DeleteUserCommandResponse> {
        public Guid UserId { get; set; }
    }
}
