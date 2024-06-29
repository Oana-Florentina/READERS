namespace Lunatic.UI.Payload
{
    public class PostDto
    {
        public Guid PostId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public Guid BookClubId { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = default!;
        public string Text { get; set; } = default!;

    }
}
