 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Services;


namespace Data.Services
{
     public interface IServiceService
    {
        List<ServiceResponseModel> GetServices();
        Service GetService(int Id);
        void CreateService(Service ServiceObj);
        void UpdateService(Service ServiceObj);
        bool DeleteService(int Id);
        List<SelectListItem> GetServiceDropdown();
         
    }
    public class ServiceService : IServiceService
    {
        
         private readonly IServiceRepository _serviceRepository = new ServiceRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<ServiceResponseModel> GetServices()
        {
                var ServiceList = (
                                           from _service in _serviceRepository.GetAll()

                                          select new ServiceResponseModel
                                          {
                                               Id = _service.Id,
Name = _service.Name,
Modifiedby = _service.Modifiedby,
Modifieddate = _service.Modifieddate,


                                          }).ToList();
                    return ServiceList;
            

        }
        public Service GetService(int Id)
        {
            var Result = _serviceRepository.GetById(Id);
            return Result;
        }
        public void CreateService(Service ServiceObj)
        {
            _serviceRepository.Add(ServiceObj);
        }
        public void UpdateService(Service ServiceObj)
        {
            _serviceRepository.Update(ServiceObj);
        }

        public bool DeleteService(int Id)
        {
            var Result = _serviceRepository.GetById(Id);
            _serviceRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetServiceDropdown()
        {
            var Result = _serviceRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Name.ToString() 

            }).ToList();
            return Result;
        }
         
    }
}
   


