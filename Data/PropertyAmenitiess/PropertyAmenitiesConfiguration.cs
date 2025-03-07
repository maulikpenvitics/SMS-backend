
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyAmenitiess
{
        public class PropertyAmenitiesConfiguration : EntityTypeConfiguration<PropertyAmenities>
        {
            public PropertyAmenitiesConfiguration()
            {
                ToTable("PropertyAmenities");
                this.HasKey(a => a.Id);
            }
        }
}
   


