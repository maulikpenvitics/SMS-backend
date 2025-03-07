 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Propertys
{
     public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
    {
        public PropertyRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyRepository : IRepository<Property>
    {

    }
}
   


