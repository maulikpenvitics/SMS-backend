 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.VendorInvoiceDetails
{
     public class VendorInvoiceDetailRepository : RepositoryBase<VendorInvoiceDetail>, IVendorInvoiceDetailRepository
    {
        public VendorInvoiceDetailRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVendorInvoiceDetailRepository : IRepository<VendorInvoiceDetail>
    {

    }
}
   


