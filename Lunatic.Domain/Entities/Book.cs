
namespace Lunatic.Domain.Entities
{
    public class Book
    {
        public Book(string title, string author, int year, string description, string cover, List<Genre> genres)
        {
            BookId = Guid.NewGuid();
            Title = title;
            Author = author;
            Year = year;
            Description = description;
            Cover = cover;
            Genres = genres;
            
        }

        public Guid BookId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public List<Genre> Genres { get; private set; } = new List<Genre>();
        public string Description { get; private set; }
        public List<Guid> Ratings { get; private set; } = new List<Guid>();
        public string Cover { get; private set; } //the urle to the cover image
    }
}