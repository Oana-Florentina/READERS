using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatic.Infrastructure.Repositories
{
    public class ReaderRepository : RepositoryBase<Reader>, IReaderRepository
    {
        public ReaderRepository(LunaticContext context) : base(context)
        {
        }

        public async Task<Result<Reader>> GetReaderByBookIdAndUserIdAsync(Guid bookId, Guid userId)
        {
            var result = await GetAllAsync();
            if (result.IsSuccess)
            {
                List<Reader> readers = result.Value.ToList();
                Reader? expectedReader = readers.Find(reader => reader.BookId == bookId && reader.UserId == userId);

                if (expectedReader == null)
                {
                    return Result<Reader>.Failure("Reader not found");
                }
                return Result<Reader>.Success(expectedReader);
            }
            return Result<Reader>.Failure("Reader not found");
        }
    }
}
