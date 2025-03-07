
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.VendorServices
{
        public class VendorServiceConfiguration : EntityTypeConfiguration<VendorService>
        {
            public VendorServiceConfiguration()
            {
                ToTable("VendorService");
                this.HasKey(a => a.Id);
            }
        }
}
   


