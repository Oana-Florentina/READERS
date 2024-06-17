using Lunatic.Application.Features.Users.Payload;
using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Mapper
{
    public class FriendRecommandationMapper
    {
        public static FriendRecommandationDto MapToFriendRecommandationDto(FriendRecommandation friendRecommandation)
        {
            return new FriendRecommandationDto
            {
                FriendRecommandationId = friendRecommandation.FriendRecommandationId,
                SenderId = friendRecommandation.SenderId,
                ReceiverId = friendRecommandation.ReceiverId,
                BookId = friendRecommandation.BookId,
            };
        }
    }
}
