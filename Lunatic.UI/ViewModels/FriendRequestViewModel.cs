namespace Lunatic.UI.ViewModels
{
    public class FriendRequestViewModel
    {
       public Guid SenderId { get; set; }
       public Guid ReceiverId { get; set; }
       public bool Status { get; set; }
    }
}
