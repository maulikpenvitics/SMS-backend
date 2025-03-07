
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Blocks
{
        public class BlockConfiguration : EntityTypeConfiguration<Block>
        {
            public BlockConfiguration()
            {
                ToTable("Block");
                this.HasKey(a => a.Id);
            }
        }
}
   


