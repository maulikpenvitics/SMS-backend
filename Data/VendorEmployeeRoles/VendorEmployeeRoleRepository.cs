 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.VendorEmployeeRoles
{
     public class VendorEmployeeRoleRepository : RepositoryBase<VendorEmployeeRole>, IVendorEmployeeRoleRepository
    {
        public VendorEmployeeRoleRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVendorEmployeeRoleRepository : IRepository<VendorEmployeeRole>
    {

    }
}
   


