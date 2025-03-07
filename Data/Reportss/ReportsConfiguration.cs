
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Reportss
{
        public class ReportsConfiguration : EntityTypeConfiguration<Reports>
        {
            public ReportsConfiguration()
            {
                ToTable("Reports");
                this.HasKey(a => a.Id);
            }
        }
}
   


