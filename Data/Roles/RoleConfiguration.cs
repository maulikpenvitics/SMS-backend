
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Roles
{
        public class RoleConfiguration : EntityTypeConfiguration<Role>
        {
            public RoleConfiguration()
            {
                ToTable("Role");
                this.HasKey(a => a.Id);
            }
        }
}
   


