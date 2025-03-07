 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Securitys
{
     public class SecurityRepository : RepositoryBase<Security>, ISecurityRepository
    {
        public SecurityRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface ISecurityRepository : IRepository<Security>
    {

    }
}
   


