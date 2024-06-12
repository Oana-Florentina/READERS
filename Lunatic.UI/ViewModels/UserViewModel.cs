namespace Lunatic.UI.ViewModels
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Guid> WantToReadIds { get; private set; } = new List<Guid>();
    }
}
