
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyOwnerss
{
        public class PropertyOwnersConfiguration : EntityTypeConfiguration<PropertyOwners>
        {
            public PropertyOwnersConfiguration()
            {
                ToTable("PropertyOwners");
                this.HasKey(a => a.Id);
            }
        }
}
   


