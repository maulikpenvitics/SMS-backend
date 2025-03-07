
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.SupportTickets
{
        public class SupportTicketConfiguration : EntityTypeConfiguration<SupportTicket>
        {
            public SupportTicketConfiguration()
            {
                ToTable("SupportTicket");
                this.HasKey(a => a.Id);
            }
        }
}
   


