 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.Propertys;


namespace Data.Propertys
{
     public interface IPropertyService
    {
        List<PropertyResponseModel> GetPropertys();
        Property GetProperty(int Id);
        void CreateProperty(Property PropertyObj);
        void UpdateProperty(Property PropertyObj);
        bool DeleteProperty(int Id);
        List<SelectListItem> GetPropertyDropdown();
         
    }
    public class PropertyService : IPropertyService
    {
        
         private readonly ICityRepository _cityRepository = new CityRepository(new DbFactory());
 private readonly IStateRepository _stateRepository = new StateRepository(new DbFactory());
 private readonly ICountryRepository _countryRepository = new CountryRepository(new DbFactory());
 private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyResponseModel> GetPropertys()
        {
                var PropertyList = (
                                           from _property in _propertyRepository.GetAll()
 join  _city in _cityRepository.GetAll() on  _property.Cityid equals _city.Id
 join  _state in _stateRepository.GetAll() on  _property.Stateid equals _state.Id
 join  _country in _countryRepository.GetAll() on  _property.Countryid equals _country.Id

                                          select new PropertyResponseModel
                                          {
                                               Id = _property.Id,
Propertyname = _property.Propertyname,
Address1 = _property.Address1,
Address2 = _property.Address2,
Cityid = _city.Id,
CityName = _city.Name,
Stateid = _state.Id,
StateName = _state.Name,
Countryid = _country.Id,
CountryName = _country.Name,
Zipcode = _property.Zipcode,
Phoneno = _property.Phoneno,
Email = _property.Email,
Modifiedby = _property.Modifiedby,
Modifieddate = _property.Modifieddate,


                                          }).ToList();
                    return PropertyList;
            

        }
        public Property GetProperty(int Id)
        {
            var Result = _propertyRepository.GetById(Id);
            return Result;
        }
        public void CreateProperty(Property PropertyObj)
        {
            _propertyRepository.Add(PropertyObj);
        }
        public void UpdateProperty(Property PropertyObj)
        {
            _propertyRepository.Update(PropertyObj);
        }

        public bool DeleteProperty(int Id)
        {
            var Result = _propertyRepository.GetById(Id);
            _propertyRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetPropertyDropdown()
        {
            var Result = _propertyRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Propertyname.ToString() 

            }).ToList();
            return Result;
        }
         
    }
}
   


