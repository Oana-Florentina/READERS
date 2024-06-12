
namespace Lunatic.Domain.Entities
{
    public class Rating
    {
        public Rating( Guid bookId, Guid userId,float score, string commentMessage)
        {
            RatingId = Guid.NewGuid();
            BookId = bookId;
            UserId = userId;
            Score = score;
            CommentMessage = commentMessage;   
        }
        public Guid RatingId { get; private set; }
        public Guid BookId { get; private set; }
        public Guid UserId { get; private set; }
        public float Score { get; private set; }
        public string CommentMessage { get; private set; }
    }
}
