using Lunatic.Application.Features.Readers.Payload;
using Lunatic.Domain.Entities;

namespace Lunatic.Application.Features.Readers.Mapper
{
    public class ReaderMapper
    {

        public static ReaderDto MapToReaderDto(Reader reader)
        {
            return new ReaderDto
            {
                ReaderId = reader.ReaderId,
                UserId = reader.UserId,
                BookId = reader.BookId,
                StartDate = reader.StartDate,
                EndDate = reader.EndDate,
                RatingId = reader.RatingId,
                IsFavorite = reader.IsFavorite,

            };
        }
    }
}
