
using Lunatic.Application.Responses;
using Lunatic.Application.Features.Ratings.Payload;


namespace Lunatic.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommandResponse : ResponseBase
    {
        public CreateRatingCommandResponse() : base() { }

        public RatingDto Rating { get; set; } = default!;
    }
}
