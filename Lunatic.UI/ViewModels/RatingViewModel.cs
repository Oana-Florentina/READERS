namespace Lunatic.UI.ViewModels
{
    public class RatingViewModel
    {
        public Guid RatingId { get;  set; }
        public Guid BookId { get;  set; }
        public Guid UserId { get;  set; }
        public float Score { get;  set; }
        public string CommentMessage { get;  set; }
    }
}
