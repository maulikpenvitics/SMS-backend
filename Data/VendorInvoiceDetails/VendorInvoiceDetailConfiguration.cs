
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.VendorInvoiceDetails
{
        public class VendorInvoiceDetailConfiguration : EntityTypeConfiguration<VendorInvoiceDetail>
        {
            public VendorInvoiceDetailConfiguration()
            {
                ToTable("VendorInvoiceDetail");
                this.HasKey(a => a.Id);
            }
        }
}
   


