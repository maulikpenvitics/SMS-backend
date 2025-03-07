 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Blocks
{
     public class BlockRepository : RepositoryBase<Block>, IBlockRepository
    {
        public BlockRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IBlockRepository : IRepository<Block>
    {

    }
}
   


