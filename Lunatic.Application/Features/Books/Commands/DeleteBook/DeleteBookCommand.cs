
using MediatR;


namespace Lunatic.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<DeleteBookCommandResponse>
    {
        public Guid BookId { get; set; }
    }
}
