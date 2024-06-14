using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;

namespace Lunatic.Infrastructure.Repositories
{
    public class CoverRepository:RepositoryBase<CoverImage>, ICoverRepository
    {
        public CoverRepository(LunaticContext context) : base(context)
    {
    }
}
}
