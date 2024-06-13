

namespace Lunatic.Application.Features.Users.Payload
{
    public class FriendRequestDto
    {
        public Guid FriendRequestId { get; set; } = default!;
        public Guid SenderId { get; set; } = default!;
        public Guid ReceiverId { get; set; } = default!;
        public bool Status { get; set; } = default!;
    }
}
