
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.AmenitiesBookings
{
        public class AmenitiesBookingConfiguration : EntityTypeConfiguration<AmenitiesBooking>
        {
            public AmenitiesBookingConfiguration()
            {
                ToTable("AmenitiesBooking");
                this.HasKey(a => a.Id);
            }
        }
}
   


