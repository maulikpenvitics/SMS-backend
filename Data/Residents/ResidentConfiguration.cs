
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Residents
{
        public class ResidentConfiguration : EntityTypeConfiguration<Resident>
        {
            public ResidentConfiguration()
            {
                ToTable("Resident");
                this.HasKey(a => a.Id);
            }
        }
}
   


