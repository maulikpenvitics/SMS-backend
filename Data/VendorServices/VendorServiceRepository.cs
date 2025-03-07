 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.VendorServices
{
     public class VendorServiceRepository : RepositoryBase<VendorService>, IVendorServiceRepository
    {
        public VendorServiceRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVendorServiceRepository : IRepository<VendorService>
    {

    }
}
   


