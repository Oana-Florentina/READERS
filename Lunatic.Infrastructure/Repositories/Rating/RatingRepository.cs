using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Infrastructure.Repositories
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public RatingRepository(LunaticContext context) : base(context)
        {
        }

       public async Task<Result<List<Rating>>> GetRatingsByBookIdAsync(Guid bookId)
        {
            var result = await GetAllAsync();
            if (result.IsSuccess)
            {
                List<Rating> ratings = result.Value.ToList();
                List<Rating> requestsForReceiver = ratings
                    .Where(fr => fr.BookId == bookId)
                    .ToList();

                if (!requestsForReceiver.Any())
                {
                    return Result<List<Rating>>.Failure($"No ratings found for book ID {bookId}");
                }
                return Result<List<Rating>>.Success(requestsForReceiver);
            }
            return Result<List<Rating>>.Failure($"Error ratings requests for book ID {bookId}");
        }
    }
}
