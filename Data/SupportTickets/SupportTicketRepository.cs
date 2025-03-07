 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.SupportTickets
{
     public class SupportTicketRepository : RepositoryBase<SupportTicket>, ISupportTicketRepository
    {
        public SupportTicketRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface ISupportTicketRepository : IRepository<SupportTicket>
    {

    }
}
   


