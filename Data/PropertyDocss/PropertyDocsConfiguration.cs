
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyDocss
{
        public class PropertyDocsConfiguration : EntityTypeConfiguration<PropertyDocs>
        {
            public PropertyDocsConfiguration()
            {
                ToTable("PropertyDocs");
                this.HasKey(a => a.Id);
            }
        }
}
   


