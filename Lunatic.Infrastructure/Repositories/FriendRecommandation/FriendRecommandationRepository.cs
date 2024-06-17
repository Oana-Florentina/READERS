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
    public class FriendRecommandationRepository : RepositoryBase<FriendRecommandation>, IFriendRecommandationRepository
    {
        public FriendRecommandationRepository(LunaticContext context) : base(context)
        {
        }

        public async Task<Result<List<FriendRecommandation>>> GetFriendRecommandationsByReceiverIdAsync(Guid receiverId)
        {
            var result = await GetAllAsync();
            if (result.IsSuccess)
            {
                List<FriendRecommandation> friendRecommandations = result.Value.ToList();
                List<FriendRecommandation> requestsForReceiver = friendRecommandations
                    .Where(fr => fr.ReceiverId == receiverId)
                    .ToList();

                if (!requestsForReceiver.Any())
                {
                    return Result<List<FriendRecommandation>>.Failure($"No friend requests found for receiver ID {receiverId}");
                }
                return Result<List<FriendRecommandation>>.Success(requestsForReceiver);
            }
            return Result<List<FriendRecommandation>>.Failure($"Error retrieving friend requests for receiver ID {receiverId}");
        }
    }
}
