

namespace Lunatic.Domain.Entities
{
    public class Book
    {
        public Book(string title, string author, string genre, int year, string description)
        {
            BookId = Guid.NewGuid();
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            Description = description;
        }

        public Guid BookId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Genre { get; private set; }
        public int Year { get; private set; }
        public string Description { get; private set; }
    }
}
