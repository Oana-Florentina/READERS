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
    public class BookClubRepository : RepositoryBase<BookClub>, IBookClubRepository
    {
        public BookClubRepository(LunaticContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
            var result = await FindByTitleAsync(title);
            return result.IsSuccess;
        }
        public async Task<Result<BookClub>> FindByTitleAsync(string title)
        {
            var result = await GetAllAsync();
            if (result.IsSuccess)
            {
                List<BookClub> bookClubs = result.Value.ToList();
                BookClub? expectedUser = bookClubs.Find(bookClub => bookClub.Title == title);

                if (expectedUser == null)
                {
                    return Result<BookClub>.Failure($"Entity with title {title} not found");
                }
                return Result<BookClub>.Success(expectedUser);
            }
            return Result<BookClub>.Failure($"Entity with username {title} not found");
        }
    }
}
