
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyVehicleTitos
{
        public class PropertyVehicleTitoConfiguration : EntityTypeConfiguration<PropertyVehicleTito>
        {
            public PropertyVehicleTitoConfiguration()
            {
                ToTable("PropertyVehicleTito");
                this.HasKey(a => a.Id);
            }
        }
}
   


