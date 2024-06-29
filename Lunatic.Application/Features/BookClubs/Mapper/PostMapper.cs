using Lunatic.Application.Features.BookClubs.Payload;
using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.BookClubs.Mapper
{
    public class PostMapper
    {

        public static PostDto MapToPostDto(PostDto post)
        {
            return new PostDto
            {
                PostId = post.PostId,
                UserId = post.UserId,
                BookClubId = post.BookClubId,
                CreatedDate = post.CreatedDate,
                Text = post.Text

            };
        }
    }
}
