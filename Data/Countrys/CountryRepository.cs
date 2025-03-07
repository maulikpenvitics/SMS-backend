 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Countrys
{
     public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface ICountryRepository : IRepository<Country>
    {

    }
}
   


