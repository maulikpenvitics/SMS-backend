
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Accountings
{
        public class AccountingConfiguration : EntityTypeConfiguration<Accounting>
        {
            public AccountingConfiguration()
            {
                ToTable("Accounting");
                this.HasKey(a => a.Id);
            }
        }
}
   


