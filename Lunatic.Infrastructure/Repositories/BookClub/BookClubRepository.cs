using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Domain.Utils;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> ExistsByTitleAsync(string title, Guid? excludeBookClubId = null)
        {
            return await context.BookClubs
                .AnyAsync(bc => bc.Title == title && (!excludeBookClubId.HasValue || bc.BookClubId != excludeBookClubId.Value));
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


        public async Task<bool> ExistById(Guid bookClubId)
        {
            var result = await GetByIdAsync(bookClubId);
            return result.IsSuccess;
        }

        public async Task<Result<BookClub>> GetByIdAsync(Guid bookClubId)
        {
            var result = await GetAllAsync();
            if (result.IsSuccess)
            {
                List<BookClub> bookClubs = result.Value.ToList();
                BookClub? expectedUser = bookClubs.Find(bookClub => bookClub.BookClubId == bookClubId);

                if (expectedUser == null)
                {
                    return Result<BookClub>.Failure($"Entity with id {bookClubId} not found");
                }
                return Result<BookClub>.Success(expectedUser);
            }
            return Result<BookClub>.Failure($"Entity with id {bookClubId} not found");
        }
    }
}
