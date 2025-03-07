 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Vendors;
 using Data.Services;
 using Data.VendorServices;
using VendorService = Domain.Entities.VendorService;


namespace Data.VendorServices
{
     public interface IVendorServiceService
    {
        List<VendorServiceResponseModel> GetVendorServices();
        VendorService GetVendorService(int Id);
        void CreateVendorService(VendorService VendorServiceObj);
        void UpdateVendorService(VendorService VendorServiceObj);
        bool DeleteVendorService(int Id);
       
         
    }
    public class VendorServiceService : IVendorServiceService
    {
        
         private readonly IVendorRepository _vendorRepository = new VendorRepository(new DbFactory());
 private readonly IServiceRepository _serviceRepository = new ServiceRepository(new DbFactory());
 private readonly IVendorServiceRepository _vendorserviceRepository = new VendorServiceRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VendorServiceResponseModel> GetVendorServices()
        {
                var VendorServiceList = (
                                           from _vendorservice in _vendorserviceRepository.GetAll()
 join  _vendor in _vendorRepository.GetAll() on  _vendorservice.VendorId equals _vendor.Id
 join  _service in _serviceRepository.GetAll() on  _vendorservice.ServiceId equals _service.Id

                                          select new VendorServiceResponseModel
                                          {
                                               Id = _vendorservice.Id,
VendorId = _vendor.Id,
vendorName = _vendor.Firstname + " " + _vendor.Lastname,
ServiceId = _service.Id,
ServiceName = _service.Name,
Modifiedby = _vendorservice.Modifiedby,
Modifieddate = _vendorservice.Modifieddate,


                                          }).ToList();
                    return VendorServiceList;
            

        }
        public VendorService GetVendorService(int Id)
        {
            var Result = _vendorserviceRepository.GetById(Id);
            return Result;
        }
        public void CreateVendorService(VendorService VendorServiceObj)
        {
            _vendorserviceRepository.Add(VendorServiceObj);
        }
        public void UpdateVendorService(VendorService VendorServiceObj)
        {
            _vendorserviceRepository.Update(VendorServiceObj);
        }

        public bool DeleteVendorService(int Id)
        {
            var Result = _vendorserviceRepository.GetById(Id);
            _vendorserviceRepository.Delete(Result);
            return true;
        }
       
         
    }
}
   


