using Lunatic.Application.Features.BookClubs.Payload;
using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.BookClubs.Mapper
{
    public class BookClubMapper
    {

        public static BookClubDto MapToBookClubDto(BookClub bookClub)
        {
            return new BookClubDto
            {
                BookClubId = bookClub.BookClubId,
                Title = bookClub.Title,
                Description = bookClub.Description,
                Books = bookClub.Books,
                Members = bookClub.Members
                
            };
        }
    }
}
