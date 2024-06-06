
using MediatR;


namespace Lunatic.Application.Features.Ratings.Commands.DeleteRating
{
    public class DeleteRatingCommand : IRequest<DeleteRatingCommandResponse>
    {
        public Guid RatingId { get; set; }
    }
}
