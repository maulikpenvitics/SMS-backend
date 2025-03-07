using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Units
{
    public class UnitConfiguration : EntityTypeConfiguration<Unit>
    {
        public UnitConfiguration()
        {
            ToTable("Unit");
            this.HasKey(a => a.Id);
        }
    }
}
