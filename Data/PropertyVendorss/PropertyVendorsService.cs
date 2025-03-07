 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyVendorss;


namespace Data.PropertyVendorss
{
     public interface IPropertyVendorsService
    {
        List<PropertyVendorsResponseModel> GetPropertyVendorss();
        PropertyVendors GetPropertyVendors(int Id);
        void CreatePropertyVendors(PropertyVendors PropertyVendorsObj);
        void UpdatePropertyVendors(PropertyVendors PropertyVendorsObj);
        bool DeletePropertyVendors(int Id);
       
         
    }
    public class PropertyVendorsService : IPropertyVendorsService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IPropertyVendorsRepository _propertyvendorsRepository = new PropertyVendorsRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyVendorsResponseModel> GetPropertyVendorss()
        {
                var PropertyVendorsList = (
                                           from _propertyvendors in _propertyvendorsRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _propertyvendors.PropertyId equals _property.Id

                                          select new PropertyVendorsResponseModel
                                          {
                                               Id = _propertyvendors.Id,
PropertyId = _property.Id,
PropertyName = _property.Propertyname,
VendorId = _propertyvendors.VendorId,
Modifiedby = _propertyvendors.Modifiedby,
Modifieddate = _propertyvendors.Modifieddate,


                                          }).ToList();
                    return PropertyVendorsList;
            

        }
        public PropertyVendors GetPropertyVendors(int Id)
        {
            var Result = _propertyvendorsRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyVendors(PropertyVendors PropertyVendorsObj)
        {
            _propertyvendorsRepository.Add(PropertyVendorsObj);
        }
        public void UpdatePropertyVendors(PropertyVendors PropertyVendorsObj)
        {
            _propertyvendorsRepository.Update(PropertyVendorsObj);
        }

        public bool DeletePropertyVendors(int Id)
        {
            var Result = _propertyvendorsRepository.GetById(Id);
            _propertyvendorsRepository.Delete(Result);
            return true;
        }
      
         
    }
}
   


