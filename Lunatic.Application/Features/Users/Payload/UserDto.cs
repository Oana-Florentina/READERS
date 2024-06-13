
using Lunatic.Domain.Entities;


namespace Lunatic.Application.Features.Users.Payload {
    public class UserDto {
        public Guid UserId { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public Role Role { get; set; } = default!;
        public List<Guid> ReaderIds { get; set; } = default!;
        public List<Guid> WantToReadIds { get; set; } = default!;

        public List<Guid> FavoriteIds { get;  set; } = default!;
        public List<Guid> BookClubIds { get; set; } = default!;
        public List<Guid> FriendsIds { get; set; } = default!;

    }
}
