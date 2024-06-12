using Lunatic.UI.Pages.Books;

namespace Lunatic.UI.Payload
{
    public class UserDto
    {
        public Guid UserId { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;

        public List<Guid> WantToReadIds { get; private set; } = new List<Guid>();

    }
}
