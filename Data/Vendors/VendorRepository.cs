 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Vendors
{
     public class VendorRepository : RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVendorRepository : IRepository<Vendor>
    {

    }
}
   


