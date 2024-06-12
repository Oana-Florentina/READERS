using Lunatic.UI.Payload;

namespace Lunatic.UI.Services.Responses
{
    public class AddRatingResponse : Response
    {
        public RatingDto Rating { get; set; } = default!;
    }
}
