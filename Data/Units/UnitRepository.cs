using Data.Infrastructure;
using Domain.Entities;

namespace Data.Units
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IUnitRepository : IRepository<Unit>
    {

    }
}
