 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyVendorss
{
     public class PropertyVendorsRepository : RepositoryBase<PropertyVendors>, IPropertyVendorsRepository
    {
        public PropertyVendorsRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyVendorsRepository : IRepository<PropertyVendors>
    {

    }
}
   


