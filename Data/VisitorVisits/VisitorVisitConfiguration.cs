
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.VisitorVisits
{
        public class VisitorVisitConfiguration : EntityTypeConfiguration<VisitorVisit>
        {
            public VisitorVisitConfiguration()
            {
                ToTable("VisitorVisit");
                this.HasKey(a => a.Id);
            }
        }
}
   


