
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyVehicles
{
        public class PropertyVehicleConfiguration : EntityTypeConfiguration<PropertyVehicle>
        {
            public PropertyVehicleConfiguration()
            {
                ToTable("PropertyVehicle");
                this.HasKey(a => a.Id);
            }
        }
}
   


