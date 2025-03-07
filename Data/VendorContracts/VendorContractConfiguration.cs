
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.VendorContracts
{
        public class VendorContractConfiguration : EntityTypeConfiguration<VendorContract>
        {
            public VendorContractConfiguration()
            {
                ToTable("VendorContract");
                this.HasKey(a => a.Id);
            }
        }
}
   


