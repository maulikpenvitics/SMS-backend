 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Roles
{
     public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IRoleRepository : IRepository<Role>
    {

    }
}
   


