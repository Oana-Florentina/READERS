namespace Lunatic.UI.ViewModels
{
    public class BookClubViewModel
    {
        public Guid BookClubId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<Guid>? Books { get; set; }
        public List<Guid>? Members { get; set; }
    }

}
