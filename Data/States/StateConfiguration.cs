
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.States
{
        public class StateConfiguration : EntityTypeConfiguration<State>
        {
            public StateConfiguration()
            {
                ToTable("State");
                this.HasKey(a => a.Id);
            }
        }
}
   


