 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.VendorEmployees
{
     public class VendorEmployeeRepository : RepositoryBase<VendorEmployee>, IVendorEmployeeRepository
    {
        public VendorEmployeeRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVendorEmployeeRepository : IRepository<VendorEmployee>
    {

    }
}
   


