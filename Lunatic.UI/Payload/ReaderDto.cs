namespace Lunatic.UI.Payload
{
    public class ReaderDto
    {
        public Guid ReaderId { get;  set; }
        public Guid BookId { get;  set; }
        public Guid UserId { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public Guid RatingId { get;  set; }
        public bool IsFavorite { get;  set; }
    }
}
