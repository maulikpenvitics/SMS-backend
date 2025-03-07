
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Billings
{
        public class BillingConfiguration : EntityTypeConfiguration<Billing>
        {
            public BillingConfiguration()
            {
                ToTable("Billing");
                this.HasKey(a => a.Id);
            }
        }
}
   


