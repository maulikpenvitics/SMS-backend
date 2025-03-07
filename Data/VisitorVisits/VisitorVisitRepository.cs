 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.VisitorVisits
{
     public class VisitorVisitRepository : RepositoryBase<VisitorVisit>, IVisitorVisitRepository
    {
        public VisitorVisitRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVisitorVisitRepository : IRepository<VisitorVisit>
    {

    }
}
   


