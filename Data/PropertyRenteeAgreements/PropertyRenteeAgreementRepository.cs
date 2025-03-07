 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.PropertyRenteeAgreements
{
     public class PropertyRenteeAgreementRepository : RepositoryBase<PropertyRenteeAgreement>, IPropertyRenteeAgreementRepository
    {
        public PropertyRenteeAgreementRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IPropertyRenteeAgreementRepository : IRepository<PropertyRenteeAgreement>
    {

    }
}
   


