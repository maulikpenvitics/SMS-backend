 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.PropertyRentees;
 using Data.PropertyRenteeAgreements;


namespace Data.PropertyRenteeAgreements
{
     public interface IPropertyRenteeAgreementService
    {
        List<PropertyRenteeAgreementResponseModel> GetPropertyRenteeAgreements();
        PropertyRenteeAgreement GetPropertyRenteeAgreement(int Id);
        void CreatePropertyRenteeAgreement(PropertyRenteeAgreement PropertyRenteeAgreementObj);
        void UpdatePropertyRenteeAgreement(PropertyRenteeAgreement PropertyRenteeAgreementObj);
        bool DeletePropertyRenteeAgreement(int Id);
       
         
    }
    public class PropertyRenteeAgreementService : IPropertyRenteeAgreementService
    {
        
         private readonly IPropertyRenteeRepository _propertyrenteeRepository = new PropertyRenteeRepository(new DbFactory());
 private readonly IPropertyRenteeAgreementRepository _propertyrenteeagreementRepository = new PropertyRenteeAgreementRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyRenteeAgreementResponseModel> GetPropertyRenteeAgreements()
        {
                var PropertyRenteeAgreementList = (
                                           from _propertyrenteeagreement in _propertyrenteeagreementRepository.GetAll()
 join  _propertyrentee in _propertyrenteeRepository.GetAll() on  _propertyrenteeagreement.PropertyRenteeId equals _propertyrentee.Id

                                          select new PropertyRenteeAgreementResponseModel
                                          {
                                               Id = _propertyrenteeagreement.Id,
PropertyId = _propertyrenteeagreement.PropertyId,
BlockId = _propertyrenteeagreement.BlockId,
Unitid = _propertyrenteeagreement.Unitid,
Agreementurl = _propertyrenteeagreement.Agreementurl,
PropertyRenteeId = _propertyrentee.Id,
PropertyRenteeName = _propertyrentee.Firstname+" "+ _propertyrentee.Lastname,
Agreementstartdate = _propertyrenteeagreement.Agreementstartdate,
Agreementenddate = _propertyrenteeagreement.Agreementenddate,
Modifiedby = _propertyrenteeagreement.Modifiedby,
Modifieddate = _propertyrenteeagreement.Modifieddate,


                                          }).ToList();
                    return PropertyRenteeAgreementList;
            

        }
        public PropertyRenteeAgreement GetPropertyRenteeAgreement(int Id)
        {
            var Result = _propertyrenteeagreementRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyRenteeAgreement(PropertyRenteeAgreement PropertyRenteeAgreementObj)
        {
            _propertyrenteeagreementRepository.Add(PropertyRenteeAgreementObj);
        }
        public void UpdatePropertyRenteeAgreement(PropertyRenteeAgreement PropertyRenteeAgreementObj)
        {
            _propertyrenteeagreementRepository.Update(PropertyRenteeAgreementObj);
        }

        public bool DeletePropertyRenteeAgreement(int Id)
        {
            var Result = _propertyrenteeagreementRepository.GetById(Id);
            _propertyrenteeagreementRepository.Delete(Result);
            return true;
        }
       
         
    }
}
   


