
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.VendorEmpRatings
{
        public class VendorEmpRatingConfiguration : EntityTypeConfiguration<VendorEmpRating>
        {
            public VendorEmpRatingConfiguration()
            {
                ToTable("VendorEmpRating");
                this.HasKey(a => a.Id);
            }
        }
}
   


