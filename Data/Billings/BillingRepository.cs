 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Billings
{
     public class BillingRepository : RepositoryBase<Billing>, IBillingRepository
    {
        public BillingRepository(IDbFactory dbFactory)
      : base(dbFactory) { }


    }
    public interface IBillingRepository : IRepository<Billing>
    {
   
    }
}
   


