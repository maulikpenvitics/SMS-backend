 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.VendorEmployeeDocs
{
     public class VendorEmployeeDocRepository : RepositoryBase<VendorEmployeeDoc>, IVendorEmployeeDocRepository
    {
        public VendorEmployeeDocRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVendorEmployeeDocRepository : IRepository<VendorEmployeeDoc>
    {

    }
}
   


