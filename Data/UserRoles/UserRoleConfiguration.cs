
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.UserRoles
{
        public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
        {
            public UserRoleConfiguration()
            {
                ToTable("UserRole");
                this.HasKey(a => a.Id);
            }
        }
}
   


