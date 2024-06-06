

using Lunatic.Domain.Entities;


namespace Lunatic.Application.Features.Ratings.Payload
{
    public class RatingDto
    {
        public Guid RatingId { get; set; } = default!;
        public Guid BookId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public float Score { get; set; } = default!;
        public string CommentMessage { get; set; } = default!;
        
    }
}
