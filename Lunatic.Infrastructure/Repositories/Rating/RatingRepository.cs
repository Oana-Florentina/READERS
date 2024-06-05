using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Infrastructure.Repositories
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public RatingRepository(LunaticContext context) : base(context)
        {
        }
    }
}
