 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyAdvertisements
{
     public class PropertyAdvertisementRepository : RepositoryBase<PropertyAdvertisement>, IPropertyAdvertisementRepository
    {
        public PropertyAdvertisementRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyAdvertisementRepository : IRepository<PropertyAdvertisement>
    {

    }
}
   


