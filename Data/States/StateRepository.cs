 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.States
{
     public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IStateRepository : IRepository<State>
    {

    }
}
   


