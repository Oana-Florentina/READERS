
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
        public List<Guid> FavoriteIds { get; private set; } = new List<Guid>();
        public List<Guid> WantToReadIds { get; private set; } = new List<Guid>();
        public List<Guid> BookClubIds { get; private set; } = new List<Guid>();
        public List<Guid> FriendsIds { get; private set; } = new List<Guid>();

        public List<Guid> FriendsRequests { get; private set; } = new List<Guid>();

        
        public void Update(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void AddWantToRead(Guid BookId)
        {
            WantToReadIds.Add(BookId);
        }

        public void AddFavorite(Guid BookId)
        {
            FavoriteIds.Add(BookId);
        }
        public void RemoveFavorite(Guid BookId)
        {
            FavoriteIds.Remove(BookId);
        }

        public void AddReader(Guid UserId, Guid BookId)
        {
            ReaderIds.Add(BookId);
        }

        public void AddFriendRequest(Guid RequestId)
        {
            FriendsRequests.Add(RequestId);
        }
        public void DeleteFriendRequest(Guid friendId, bool status)
        {
            if (status)
            {
                FriendsIds.Add(friendId);
            }
        }
        public void RemoveFriendRequest(Guid requestId)
        {
            FriendsRequests.Remove(requestId);
        }
        public void AddBookClub(Guid bookClubId)
        {
            BookClubIds.Add(bookClubId);
        }
        public void RemoveBookClub(Guid bookClubId)
        {
            BookClubIds.Remove(bookClubId);
        }

    }
}
