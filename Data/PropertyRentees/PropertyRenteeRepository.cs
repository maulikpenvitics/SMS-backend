 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyRentees
{
     public class PropertyRenteeRepository : RepositoryBase<PropertyRentee>, IPropertyRenteeRepository
    {
        public PropertyRenteeRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyRenteeRepository : IRepository<PropertyRentee>
    {

    }
}
   


