using Lunatic.Application.Features.Users.Payload;
using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Mapper
{
    public class UserMapper
    {

        public static UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role,
                ReaderIds = user.ReaderIds,
                WantToReadIds = user.WantToReadIds,
                FavoriteIds = user.FavoriteIds,
                FriendsIds = user.FriendsIds,
                FriendsRequests = user.FriendsRequests,
                BookClubIds = user.BookClubIds

            };
        }
    }
}
//fac la fel pt celelalte clase