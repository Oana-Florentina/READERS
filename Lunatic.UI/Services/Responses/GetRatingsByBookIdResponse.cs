using Lunatic.UI.Payload;
namespace Lunatic.UI.Services.Responses
{
    public class GetRatingsByBookIdResponse :Response
    {
        public List<RatingDto> Ratings { get; set; } = default!;
    }
}
