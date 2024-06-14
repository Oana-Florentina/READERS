using Lunatic.Application.Features.Books.Payload;
using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Books.Mapper
{
    public class BookMapper
    {

        public static BookDto MapToBookDto(Book book)
        {
            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Year = book.Year,
                Ratings = book.Ratings,
                Cover = book.Cover
            };
        }
    }
}
