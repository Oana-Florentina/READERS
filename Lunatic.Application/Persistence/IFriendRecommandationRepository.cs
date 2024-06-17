using Lunatic.Domain.Entities;
using Lunatic.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Persistence
{
    public interface IFriendRecommandationRepository : IAsyncRepository<FriendRecommandation>
    {
        Task<Result<List<FriendRecommandation>>> GetFriendRecommandationsByReceiverIdAsync(Guid receiverId);

    }
}
