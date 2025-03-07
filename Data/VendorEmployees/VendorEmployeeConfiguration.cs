
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.VendorEmployees
{
        public class VendorEmployeeConfiguration : EntityTypeConfiguration<VendorEmployee>
        {
            public VendorEmployeeConfiguration()
            {
                ToTable("VendorEmployee");
                this.HasKey(a => a.VendorEmployeeId);
            }
        }
}
   


