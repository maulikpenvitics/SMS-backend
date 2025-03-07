 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.VendorEmpRatings
{
     public class VendorEmpRatingRepository : RepositoryBase<VendorEmpRating>, IVendorEmpRatingRepository
    {
        public VendorEmpRatingRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IVendorEmpRatingRepository : IRepository<VendorEmpRating>
    {

    }
}
   


