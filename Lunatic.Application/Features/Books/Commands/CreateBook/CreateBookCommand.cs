
using Lunatic.Domain.Entities;
using MediatR;


namespace Lunatic.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<CreateBookCommandResponse>
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public int Year { get; set; } = default!;
        public string Description { get; set; } = default!;
       
        public string Cover { get; set; } = default!;
        public string Genres { get; set; } = default!;
    }
}
