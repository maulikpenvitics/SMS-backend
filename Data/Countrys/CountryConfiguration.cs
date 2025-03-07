
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Countrys
{
        public class CountryConfiguration : EntityTypeConfiguration<Country>
        {
            public CountryConfiguration()
            {
                ToTable("Country");
                this.HasKey(a => a.Id);
            }
        }
}
   


