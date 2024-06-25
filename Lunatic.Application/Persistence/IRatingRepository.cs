using Lunatic.Domain.Entities;
using Lunatic.Domain.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Persistence
{
    public interface IRatingRepository : IAsyncRepository<Rating>
    {
        Task<Result<List<Rating>>> GetRatingsByBookIdAsync(Guid bookId);
    }
}
