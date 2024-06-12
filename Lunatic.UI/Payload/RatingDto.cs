namespace Lunatic.UI.Payload
{
    public class RatingDto
    {
        public Guid RatingId { get;  set; }
        public Guid BookId { get;  set; }
        public Guid UserId { get;  set; }
        public float Score { get;  set; }
        public string CommentMessage { get;  set; }
    }
}
