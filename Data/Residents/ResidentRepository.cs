 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Residents
{
     public class ResidentRepository : RepositoryBase<Resident>, IResidentRepository
    {
        public ResidentRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IResidentRepository : IRepository<Resident>
    {

    }
}
   


