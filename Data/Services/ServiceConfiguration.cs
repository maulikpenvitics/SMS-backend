
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Services
{
        public class ServiceConfiguration : EntityTypeConfiguration<Service>
        {
            public ServiceConfiguration()
            {
                ToTable("Service");
                this.HasKey(a => a.Id);
            }
        }
}
   


