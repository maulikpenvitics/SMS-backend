
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyRentees
{
        public class PropertyRenteeConfiguration : EntityTypeConfiguration<PropertyRentee>
        {
            public PropertyRenteeConfiguration()
            {
                ToTable("PropertyRentee");
                this.HasKey(a => a.Id);
            }
        }
}
   


