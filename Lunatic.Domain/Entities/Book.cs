

namespace Lunatic.Domain.Entities
{
    public class Book
    {
        public Book(string title, string author, string genre, int year, string description, float averageScore)
        {
            BookId = Guid.NewGuid();
            Title = title;
            Author = author;
            Year = year;
            Description = description;
            AverageScore = averageScore;
        }

        public Guid BookId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public string Description { get; private set; }
        public float AverageScore { get; private set; }
        public List<Guid> Ratings { get; private set; } = new List<Guid>();
        public List<Genre> Genres { get; private set; } = new List<Genre>();
        public Guid cover { get; private set; }
    }
}