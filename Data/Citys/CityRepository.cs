 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Citys
{
     public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface ICityRepository : IRepository<City>
    {

    }
}
   


