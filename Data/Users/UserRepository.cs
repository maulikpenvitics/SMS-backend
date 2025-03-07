 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Users
{
     public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IUserRepository : IRepository<User>
    {

    }
}
   


