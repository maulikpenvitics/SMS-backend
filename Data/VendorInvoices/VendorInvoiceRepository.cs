 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.VendorInvoices
{
     public class VendorInvoiceRepository : RepositoryBase<VendorInvoice>, IVendorInvoiceRepository
    {
        public VendorInvoiceRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVendorInvoiceRepository : IRepository<VendorInvoice>
    {

    }
}
   


