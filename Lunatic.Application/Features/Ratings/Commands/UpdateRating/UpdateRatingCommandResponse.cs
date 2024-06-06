using Lunatic.Application.Responses;
using Lunatic.Application.Features.Ratings.Payload;

namespace Lunatic.Application.Features.Ratings.Commands.UpdateRating
{
    public class UpdateRatingCommandResponse : ResponseBase
    {
        public UpdateRatingCommandResponse() : base()
        {

        }
        public RatingDto Rating { get; set; } = default!;
    }
}
