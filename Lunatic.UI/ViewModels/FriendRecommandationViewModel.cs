using System;

namespace Lunatic.Domain.Entities
{
    public class FriendRecommandationViewModel
    {
        public Guid FriendRecommandationId { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid RecommendedFriendId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
