using Lunatic.UI.Payload;
namespace Lunatic.UI.Services.Responses

{
    public class GetFriendRecommandationByReceiverIdResponse : Response
    {

        public List<FriendRecommandationDto> FriendRecommandations { get; set; } = default!;
    }
}
