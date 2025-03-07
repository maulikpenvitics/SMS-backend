
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyVendorss
{
        public class PropertyVendorsConfiguration : EntityTypeConfiguration<PropertyVendors>
        {
            public PropertyVendorsConfiguration()
            {
                ToTable("PropertyVendors");
                this.HasKey(a => a.Id);
            }
        }
}
   


