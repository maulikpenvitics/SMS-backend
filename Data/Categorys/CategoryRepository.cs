 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Categorys
{
     public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface ICategoryRepository : IRepository<Category>
    {

    }
}
   


