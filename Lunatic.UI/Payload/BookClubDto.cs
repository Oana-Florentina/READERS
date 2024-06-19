namespace Lunatic.UI.Payload
{
    public class BookClubDto
    {
        public Guid BookClubId { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<Guid> Books { get; set; } = default!;
        public List<Guid> Members { get; set; } = default!;
    }
}