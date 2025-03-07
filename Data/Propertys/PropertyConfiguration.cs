
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Propertys
{
        public class PropertyConfiguration : EntityTypeConfiguration<Property>
        {
            public PropertyConfiguration()
            {
                ToTable("Property");
                this.HasKey(a => a.Id);
            }
        }
}
   


