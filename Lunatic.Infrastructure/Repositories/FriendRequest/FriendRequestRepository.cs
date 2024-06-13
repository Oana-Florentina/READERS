using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Infrastructure.Repositories
{
    
    public class FriendRequestRepository : RepositoryBase<FriendRequest>, IFriendRequestRepository
    {
        public FriendRequestRepository(LunaticContext context) : base(context)
        {
        }
    }
}
