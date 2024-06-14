using Lunatic.Domain.Entities;
using Lunatic.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Persistence
{
    public interface IFriendRequestRepository : IAsyncRepository<FriendRequest>
    {
        Task<Result<List<FriendRequest>>> GetFriendRequestsByReceiverIdAsync(Guid receiverId);

    }
}
