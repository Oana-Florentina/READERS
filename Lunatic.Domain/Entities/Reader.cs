
namespace Lunatic.Domain.Entities
{
    public class Reader
    {
        public Reader(Guid bookId, Guid userId, DateTime startDate, DateTime endDate, Guid ratingId, Book isFavorite)
        {
            BookId = bookId;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            RatingId = ratingId;
            IsFavorite = isFavorite;
        }

        public Guid BookId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Guid RatingId { get; private set; }
        public Book IsFavorite { get; private set; }
    }
}
