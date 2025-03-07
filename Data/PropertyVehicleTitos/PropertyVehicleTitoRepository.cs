 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyVehicleTitos
{
     public class PropertyVehicleTitoRepository : RepositoryBase<PropertyVehicleTito>, IPropertyVehicleTitoRepository
    {
        public PropertyVehicleTitoRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyVehicleTitoRepository : IRepository<PropertyVehicleTito>
    {

    }
}
   


