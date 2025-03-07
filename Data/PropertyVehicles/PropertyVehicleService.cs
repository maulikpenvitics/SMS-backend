 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyVehicles;


namespace Data.PropertyVehicles
{
     public interface IPropertyVehicleService
    {
        List<PropertyVehicleResponseModel> GetPropertyVehicles();
        PropertyVehicle GetPropertyVehicle(int Id);
        void CreatePropertyVehicle(PropertyVehicle PropertyVehicleObj);
        void UpdatePropertyVehicle(PropertyVehicle PropertyVehicleObj);
        bool DeletePropertyVehicle(int Id);
        
         
    }
    public class PropertyVehicleService : IPropertyVehicleService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IPropertyVehicleRepository _propertyvehicleRepository = new PropertyVehicleRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyVehicleResponseModel> GetPropertyVehicles()
        {
                var PropertyVehicleList = (
                                           from _propertyvehicle in _propertyvehicleRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _propertyvehicle.PropertyId equals _property.Id

                                          select new PropertyVehicleResponseModel
                                          {
                                               Id = _propertyvehicle.Id,
PropertyId = _property.Id,
PropertyName = _property.Propertyname,
Vehiclenumber = _propertyvehicle.Vehiclenumber,
Model = _propertyvehicle.Model,
PropertyOwnersId = _propertyvehicle.PropertyOwnersId,
Modifiedby = _propertyvehicle.Modifiedby,
Modifieddate = _propertyvehicle.Modifieddate,


                                          }).ToList();
                    return PropertyVehicleList;
            

        }
        public PropertyVehicle GetPropertyVehicle(int Id)
        {
            var Result = _propertyvehicleRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyVehicle(PropertyVehicle PropertyVehicleObj)
        {
            _propertyvehicleRepository.Add(PropertyVehicleObj);
        }
        public void UpdatePropertyVehicle(PropertyVehicle PropertyVehicleObj)
        {
            _propertyvehicleRepository.Update(PropertyVehicleObj);
        }

        public bool DeletePropertyVehicle(int Id)
        {
            var Result = _propertyvehicleRepository.GetById(Id);
            _propertyvehicleRepository.Delete(Result);
            return true;
        }
       
         
    }
}
   


