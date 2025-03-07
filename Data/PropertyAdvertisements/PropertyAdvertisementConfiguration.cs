
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyAdvertisements
{
        public class PropertyAdvertisementConfiguration : EntityTypeConfiguration<PropertyAdvertisement>
        {
            public PropertyAdvertisementConfiguration()
            {
                ToTable("PropertyAdvertisement");
                this.HasKey(a => a.Id);
            }
        }
}
   


