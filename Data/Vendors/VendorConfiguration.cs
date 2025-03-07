
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Vendors
{
        public class VendorConfiguration : EntityTypeConfiguration<Vendor>
        {
            public VendorConfiguration()
            {
                ToTable("Vendor");
                this.HasKey(a => a.Id);
            }
        }
}
   


