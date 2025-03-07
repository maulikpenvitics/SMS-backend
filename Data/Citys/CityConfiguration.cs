
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Citys
{
        public class CityConfiguration : EntityTypeConfiguration<City>
        {
            public CityConfiguration()
            {
                ToTable("City");
                this.HasKey(a => a.Id);
            }
        }
}
   


