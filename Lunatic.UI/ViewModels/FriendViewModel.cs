namespace Lunatic.UI.ViewModels
{
    public class FriendViewModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public bool IsChecked { get; set; } // This property is used for selecting friends in the UI

        public FriendViewModel(Guid userId, string username)
        {
            UserId = userId;
            Username = username;
            IsChecked = false; // Default value
        }
    }

}
