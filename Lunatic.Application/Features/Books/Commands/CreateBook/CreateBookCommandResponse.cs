
using Lunatic.Application.Responses;
using Lunatic.Application.Features.Books.Payload;


namespace Lunatic.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandResponse : ResponseBase
    {
        public CreateBookCommandResponse() : base() { }

        public BookDto Book { get; set; } = default!;
    }
}
