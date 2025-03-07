 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.PropertyVehicles;
 using Data.PropertyVehicleTitos;


namespace Data.PropertyVehicleTitos
{
     public interface IPropertyVehicleTitoService
    {
        List<PropertyVehicleTitoResponseModel> GetPropertyVehicleTitos();
        PropertyVehicleTito GetPropertyVehicleTito(int Id);
        void CreatePropertyVehicleTito(PropertyVehicleTito PropertyVehicleTitoObj);
        void UpdatePropertyVehicleTito(PropertyVehicleTito PropertyVehicleTitoObj);
        bool DeletePropertyVehicleTito(int Id);
      
         
    }
    public class PropertyVehicleTitoService : IPropertyVehicleTitoService
    {
        
         private readonly IPropertyVehicleRepository _propertyvehicleRepository = new PropertyVehicleRepository(new DbFactory());
 private readonly IPropertyVehicleTitoRepository _propertyvehicletitoRepository = new PropertyVehicleTitoRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyVehicleTitoResponseModel> GetPropertyVehicleTitos()
        {
                var PropertyVehicleTitoList = (
                                           from _propertyvehicletito in _propertyvehicletitoRepository.GetAll()
 join  _propertyvehicle in _propertyvehicleRepository.GetAll() on  _propertyvehicletito.PropertyVehicleId equals _propertyvehicle.Id

                                          select new PropertyVehicleTitoResponseModel
                                          {
                                               Id = _propertyvehicletito.Id,
PropertyVehicleId = _propertyvehicle.Id,
Checkintime = _propertyvehicletito.Checkintime,
Checkouttime = _propertyvehicletito.Checkouttime,
Modifiedby = _propertyvehicletito.Modifiedby,
Modifieddate = _propertyvehicletito.Modifieddate,


                                          }).ToList();
                    return PropertyVehicleTitoList;
            

        }
        public PropertyVehicleTito GetPropertyVehicleTito(int Id)
        {
            var Result = _propertyvehicletitoRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyVehicleTito(PropertyVehicleTito PropertyVehicleTitoObj)
        {
            _propertyvehicletitoRepository.Add(PropertyVehicleTitoObj);
        }
        public void UpdatePropertyVehicleTito(PropertyVehicleTito PropertyVehicleTitoObj)
        {
            _propertyvehicletitoRepository.Update(PropertyVehicleTitoObj);
        }

        public bool DeletePropertyVehicleTito(int Id)
        {
            var Result = _propertyvehicletitoRepository.GetById(Id);
            _propertyvehicletitoRepository.Delete(Result);
            return true;
        }
    
         
    }
}
   


