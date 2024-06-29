using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lunatic.Infrastructure.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(LunaticContext context) : base(context)
        {
        }

        public async Task<Result<List<Post>>> GetPostsByBookClubIdAsync(Guid bookClubId)
        {
            var result = await GetAllAsync();
            if (result.IsSuccess)
            {
                List<Post> posts = result.Value.ToList();
                List<Post> requestsForBookClub = posts
                    .Where(fr => fr.BookClubId == bookClubId)
                    .ToList();

                if (!requestsForBookClub.Any())
                {
                    return Result<List<Post>>.Failure($"No friend requests found for BookClub ID {bookClubId}");
                }
                return Result<List<Post>>.Success(requestsForBookClub);
            }
            return Result<List<Post>>.Failure($"Error retrieving friend requests for BookClub ID {bookClubId}");
        }
    }
}
