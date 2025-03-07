
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyRenteeAgreements
{
        public class PropertyRenteeAgreementConfiguration : EntityTypeConfiguration<PropertyRenteeAgreement>
        {
            public PropertyRenteeAgreementConfiguration()
            {
                ToTable("PropertyRenteeAgreement");
                this.HasKey(a => a.Id);
            }
        }
}
   


