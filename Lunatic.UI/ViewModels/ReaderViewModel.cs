namespace Lunatic.UI.ViewModels
{
    public class ReaderViewModel
    {
        public Guid ReaderId { get;  set; }
        public Guid BookId { get;  set; }
        public Guid UserId { get;  set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Guid RatingId { get;  set; }
        public bool IsFavorite { get;  set; }
    }
}
