
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Users
{
        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                ToTable("User");
                this.HasKey(a => a.Id);
            }
        }
}
   


