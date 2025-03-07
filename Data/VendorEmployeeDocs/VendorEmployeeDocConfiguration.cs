
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.VendorEmployeeDocs
{
        public class VendorEmployeeDocConfiguration : EntityTypeConfiguration<VendorEmployeeDoc>
        {
            public VendorEmployeeDocConfiguration()
            {
                ToTable("VendorEmployeeDoc");
                this.HasKey(a => a.Id);
            }
        }
}
   


