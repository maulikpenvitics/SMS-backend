
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.VendorEmployeeRoles
{
        public class VendorEmployeeRoleConfiguration : EntityTypeConfiguration<VendorEmployeeRole>
        {
            public VendorEmployeeRoleConfiguration()
            {
                ToTable("VendorEmployeeRole");
                this.HasKey(a => a.Id);
            }
        }
}
   


