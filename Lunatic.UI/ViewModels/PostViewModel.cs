namespace Lunatic.UI.ViewModels
{
    public class PostViewModel
    {
        public Guid PostId { get; set; } 
        public Guid UserId { get; set; } 
        public Guid BookClubId { get; set; } 
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
