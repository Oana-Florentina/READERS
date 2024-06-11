
using Lunatic.Domain.Utils;

namespace Lunatic.Domain.Entities {
    public class User {
        public User(string firstName, string lastName, string email, string username, string password, Role role)
        {
            UserId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            Role = role;
        }
        public Guid UserId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }
        public List<Guid> ReaderIds { get; private set; } = new List<Guid>();
        public List<Guid> WantToReadIds { get; private set; } = new List<Guid>();
        public List<Guid> BookClubIds { get; private set; } = new List<Guid>();
        public List<Guid> FriendsIds { get; private set; } = new List<Guid>();

        
        public void Update(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

     
    }
}
