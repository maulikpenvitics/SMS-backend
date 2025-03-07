 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.VendorContracts
{
     public class VendorContractRepository : RepositoryBase<VendorContract>, IVendorContractRepository
    {
        public VendorContractRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVendorContractRepository : IRepository<VendorContract>
    {

    }
}
   


