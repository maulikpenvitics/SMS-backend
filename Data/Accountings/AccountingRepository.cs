 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Accountings
{
     public class AccountingRepository : RepositoryBase<Accounting>, IAccountingRepository
    {
        public AccountingRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IAccountingRepository : IRepository<Accounting>
    {

    }
}
   


