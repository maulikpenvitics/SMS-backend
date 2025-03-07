 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.AmenitiesBookings
{
     public class AmenitiesBookingRepository : RepositoryBase<AmenitiesBooking>, IAmenitiesBookingRepository
    {
        public AmenitiesBookingRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IAmenitiesBookingRepository : IRepository<AmenitiesBooking>
    {

    }
}
   


