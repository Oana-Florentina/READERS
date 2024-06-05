

using Lunatic.Domain.Entities;


namespace Lunatic.Application.Features.Readers.Payload
{
    public class ReaderDto
    {
        public Guid ReaderId { get; set; } = default!;
        public Guid BookId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public Guid RatingId { get; set; } = default!;
        public bool IsFavorite { get; set; } = default!;    
    }
}
