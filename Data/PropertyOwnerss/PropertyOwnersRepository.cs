 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyOwnerss
{
     public class PropertyOwnersRepository : RepositoryBase<PropertyOwners>, IPropertyOwnersRepository
    {
        public PropertyOwnersRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyOwnersRepository : IRepository<PropertyOwners>
    {

    }
}
   


