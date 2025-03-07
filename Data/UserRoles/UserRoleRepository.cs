 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.UserRoles
{
     public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IUserRoleRepository : IRepository<UserRole>
    {

    }
}
   


