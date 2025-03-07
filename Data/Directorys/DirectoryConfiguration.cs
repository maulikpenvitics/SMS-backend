
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Directorys
{
        public class DirectoryConfiguration : EntityTypeConfiguration<Directory>
        {
            public DirectoryConfiguration()
            {
                ToTable("Directory");
                this.HasKey(a => a.Id);
            }
        }
}
   


