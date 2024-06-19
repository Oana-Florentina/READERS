using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Domain.Entities
{
    public class BookClub
    {
        public BookClub(string title, string description)
        {
            BookClubId = Guid.NewGuid();
            Title = title;
            Description = description;
        }
        public Guid BookClubId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<Guid> Books { get; private set; } = new List<Guid>();
        public List<Guid> Members { get; private set; } = new List<Guid>();

        public void addMember(Guid userId)
        {
            Members.Add(userId);
        }
        public void removeMember(Guid userId) {
            Members.Remove(userId);
        }
        public void addBook(Guid bookId)
        {
            Books.Add(bookId);
        }
        public void removeBook(Guid bookId)
        {
            Books.Remove(bookId);
        }
        public void Update(string title, string description, List<Guid> members, List<Guid> books)
        {
            Title = title;
            Description = description;
            Members = members;
            Books = books;
        }
    }
  
}
