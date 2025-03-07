
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Securitys
{
        public class SecurityConfiguration : EntityTypeConfiguration<Security>
        {
            public SecurityConfiguration()
            {
                ToTable("Security");
                this.HasKey(a => a.Id);
            }
        }
}
   


