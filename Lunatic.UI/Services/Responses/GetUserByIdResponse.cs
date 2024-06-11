using Lunatic.UI.Payload;

namespace Lunatic.UI.Services.Responses
{
    public class GetUserByIdResponse : Response
    {
        public UserDto User { get; set; } = default!;
    }
}
