 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyVehicles
{
     public class PropertyVehicleRepository : RepositoryBase<PropertyVehicle>, IPropertyVehicleRepository
    {
        public PropertyVehicleRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyVehicleRepository : IRepository<PropertyVehicle>
    {

    }
}
   


