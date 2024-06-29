using Lunatic.UI.Payload;



namespace Lunatic.UI.Services.Responses
{
    public class CreatePostResponse : Response
    {
        public PostDto Post { get; set; } = default!;
    }
}