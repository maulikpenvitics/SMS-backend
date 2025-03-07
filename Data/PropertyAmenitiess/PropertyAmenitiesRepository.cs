 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyAmenitiess
{
     public class PropertyAmenitiesRepository : RepositoryBase<PropertyAmenities>, IPropertyAmenitiesRepository
    {
        public PropertyAmenitiesRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyAmenitiesRepository : IRepository<PropertyAmenities>
    {

    }
}
   


