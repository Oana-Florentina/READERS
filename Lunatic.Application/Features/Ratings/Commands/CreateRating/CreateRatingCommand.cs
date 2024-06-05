
using Lunatic.Domain.Entities;
using MediatR;


namespace Lunatic.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommand : IRequest<CreateRatingCommandResponse>
    {
        public Guid UserId { get; set; } = default!;
        public Guid BookId { get; set; } = default!;
        public Guid RatingId { get; set; } = default!;
        public float Score { get;  set; } = default!;
        public string CommentMessage { get; set; } = default!;

    }
}
