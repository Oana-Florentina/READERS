using Lunatic.Domain.Entities;


namespace Lunatic.Application.Features.Books.Payload
{
    public class BookDto
    {
        public Guid BookId { get; set; } = default!;
        public string Title { get;  set; } = default!;
        public string Author { get;  set; } = default!;
        public int Year { get;  set; } = default!;
        public string Description { get;  set; } = default!;
        public float AverageScore { get;  set; } = default!;
        public List<Guid> Ratings { get;  set; } = default!;
        public string Genres { get;  set; } = default!;
        public string Cover { get;  set; } = default!;
    }
}
