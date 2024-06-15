using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Domain.Entities
{
    public class BookClub
    {
        public BookClub(Guid bookClubId, string title, string description, string genres)
        {
            BookClubId = bookClubId;
            Title = title;
            Description = description;
            Genres = genres;
        }
        public Guid BookClubId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<Guid> Books { get; private set; } = new List<Guid>();
        public List<Guid> Members { get; private set; } = new List<Guid>();
        public string Genres { get; private set; } 
    }
}
