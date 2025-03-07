
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.VendorInvoices
{
        public class VendorInvoiceConfiguration : EntityTypeConfiguration<VendorInvoice>
        {
            public VendorInvoiceConfiguration()
            {
                ToTable("VendorInvoice");
                this.HasKey(a => a.Id);
            }
        }
}
   


