
namespace Lunatic.Domain.Entities
{
    public class Rating
    {
        public Rating(Guid ratingId, Guid bookId, Guid userId,float score, string commentMessage)
        {
            RatingId = ratingId;
            BookId = bookId;
            UserId = userId;
            Score = score;
            CommentMessage = commentMessage;   
        }
        public Guid RatingId { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public float Score { get; set; }
        public string CommentMessage { get; set; }
    }
}
