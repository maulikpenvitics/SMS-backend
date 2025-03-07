 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Services
{
     public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IServiceRepository : IRepository<Service>
    {

    }
}
   


