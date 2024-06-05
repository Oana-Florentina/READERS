using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Infrastructure.Repositories
{
    public class ReaderRepository : RepositoryBase<Reader>, IReaderRepository
    {
        public ReaderRepository(LunaticContext context) : base(context)
        {
        }
    }
}
