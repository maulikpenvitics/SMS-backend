 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyAssetss
{
     public class PropertyAssetsRepository : RepositoryBase<PropertyAssets>, IPropertyAssetsRepository
    {
        public PropertyAssetsRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyAssetsRepository : IRepository<PropertyAssets>
    {

    }
}
   


