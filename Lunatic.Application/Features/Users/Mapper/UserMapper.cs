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
                BookClubIds = user.BookClubIds,
                FriendsIds = user.FriendsIds

            };
        }
    }
}
//fac la fel pt celelalte clase