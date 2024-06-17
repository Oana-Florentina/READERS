using System;

namespace Lunatic.UI.ViewModels
{
    public class FriendRecommandationViewModel
    {
        public Guid FriendRecommandationId { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid BookId{ get; set; }
    }
}
