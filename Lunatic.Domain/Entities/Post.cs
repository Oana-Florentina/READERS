using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Domain.Entities
{
    public class Post
    {
        public Post(Guid userId, Guid bookClubId, string text)
        {
            PostId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            UserId = userId;
            BookClubId = bookClubId;
            Text = text;
        }

        public Guid PostId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public Guid BookClubId { get; private set; }
        public string Text { get; private set; }
    }
}
