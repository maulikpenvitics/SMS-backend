
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Visitors
{
        public class VisitorConfiguration : EntityTypeConfiguration<Visitor>
        {
            public VisitorConfiguration()
            {
                ToTable("Visitor");
                this.HasKey(a => a.Id);
            }
        }
}
   


