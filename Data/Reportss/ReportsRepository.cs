 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Reportss
{
     public class ReportsRepository : RepositoryBase<Reports>, IReportsRepository
    {
        public ReportsRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IReportsRepository : IRepository<Reports>
    {

    }
}
   


