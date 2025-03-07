 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyDocss
{
     public class PropertyDocsRepository : RepositoryBase<PropertyDocs>, IPropertyDocsRepository
    {
        public PropertyDocsRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyDocsRepository : IRepository<PropertyDocs>
    {

    }
}
   


