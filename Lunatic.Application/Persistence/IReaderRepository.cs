using Lunatic.Domain.Entities;
using Lunatic.Domain.Utils;

namespace Lunatic.Application.Persistence
{
    public interface IReaderRepository : IAsyncRepository<Reader>
    {
        Task<Result<Reader>> GetReaderByBookIdAndUserIdAsync(Guid bookId, Guid userId);

    }
}
