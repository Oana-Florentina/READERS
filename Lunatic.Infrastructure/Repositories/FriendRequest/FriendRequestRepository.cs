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
    public class FriendRequestRepository : RepositoryBase<FriendRequest>, IFriendRequestRepository
    {
        public FriendRequestRepository(LunaticContext context) : base(context)
        {
        }

        public async Task<Result<List<FriendRequest>>> GetFriendRequestsByReceiverIdAsync(Guid receiverId)
        {
            var result = await GetAllAsync();
            if (result.IsSuccess)
            {
                List<FriendRequest> friendRequests = result.Value.ToList();
                List<FriendRequest> requestsForReceiver = friendRequests
                    .Where(fr => fr.ReceiverId == receiverId)
                    .ToList();

                if (!requestsForReceiver.Any())
                {
                    return Result<List<FriendRequest>>.Failure($"No friend requests found for receiver ID {receiverId}");
                }
                return Result<List<FriendRequest>>.Success(requestsForReceiver);
            }
            return Result<List<FriendRequest>>.Failure($"Error retrieving friend requests for receiver ID {receiverId}");
        }
    }
}
