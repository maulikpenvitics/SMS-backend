 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyAdvertisements;


namespace Data.PropertyAdvertisements
{
     public interface IPropertyAdvertisementService
    {
        List<PropertyAdvertisementResponseModel> GetPropertyAdvertisements();
        PropertyAdvertisement GetPropertyAdvertisement(int Id);
        void CreatePropertyAdvertisement(PropertyAdvertisement PropertyAdvertisementObj);
        void UpdatePropertyAdvertisement(PropertyAdvertisement PropertyAdvertisementObj);
        bool DeletePropertyAdvertisement(int Id);
        List<SelectListItem> GetPropertyAdvertisementDropdown();
         
    }
    public class PropertyAdvertisementService : IPropertyAdvertisementService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IPropertyAdvertisementRepository _propertyadvertisementRepository = new PropertyAdvertisementRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyAdvertisementResponseModel> GetPropertyAdvertisements()
        {
                var PropertyAdvertisementList = (
                                           from _propertyadvertisement in _propertyadvertisementRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _propertyadvertisement.PropertyId equals _property.Id

                                          select new PropertyAdvertisementResponseModel
                                          {
                                               Id = _propertyadvertisement.Id,
PropertyId = _property.Id,
PropertyName = _property.Propertyname,
Location = _propertyadvertisement.Location,
Fromdate = _propertyadvertisement.Fromdate,
Todate = _propertyadvertisement.Todate,
Amount = _propertyadvertisement.Amount,
Companyname = _propertyadvertisement.Companyname,
Advertisorfirstname = _propertyadvertisement.Advertisorfirstname,
Advertisorlastname = _propertyadvertisement.Advertisorlastname,
Modifiedby = _propertyadvertisement.Modifiedby,
Modifieddate = _propertyadvertisement.Modifieddate,


                                          }).ToList();
                    return PropertyAdvertisementList;
            

        }
        public PropertyAdvertisement GetPropertyAdvertisement(int Id)
        {
            var Result = _propertyadvertisementRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyAdvertisement(PropertyAdvertisement PropertyAdvertisementObj)
        {
            _propertyadvertisementRepository.Add(PropertyAdvertisementObj);
        }
        public void UpdatePropertyAdvertisement(PropertyAdvertisement PropertyAdvertisementObj)
        {
            _propertyadvertisementRepository.Update(PropertyAdvertisementObj);
        }

        public bool DeletePropertyAdvertisement(int Id)
        {
            var Result = _propertyadvertisementRepository.GetById(Id);
            _propertyadvertisementRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetPropertyAdvertisementDropdown()
        {
            var Result = _propertyadvertisementRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Advertisorfirstname+" "+x.Advertisorlastname

            }).ToList();
            return Result;
        }
         
    }
}
   


