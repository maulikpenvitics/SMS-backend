 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Visitors
{
     public class VisitorRepository : RepositoryBase<Visitor>, IVisitorRepository
    {
        public VisitorRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVisitorRepository : IRepository<Visitor>
    {

    }
}
   


