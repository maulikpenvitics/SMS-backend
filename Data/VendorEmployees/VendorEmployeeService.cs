 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Vendors;
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.VendorEmployees;


namespace Data.VendorEmployees
{
     public interface IVendorEmployeeService
    {
        List<VendorEmployeeResponseModel> GetVendorEmployees();
        VendorEmployee GetVendorEmployee(int Id);
        void CreateVendorEmployee(VendorEmployee VendorEmployeeObj);
        void UpdateVendorEmployee(VendorEmployee VendorEmployeeObj);
        bool DeleteVendorEmployee(int Id);
        List<SelectListItem> GetVendorEmployeeDropdown();
         
    }
    public class VendorEmployeeService : IVendorEmployeeService
    {
        
         private readonly IVendorRepository _vendorRepository = new VendorRepository(new DbFactory());
 private readonly ICityRepository _cityRepository = new CityRepository(new DbFactory());
 private readonly IStateRepository _stateRepository = new StateRepository(new DbFactory());
 private readonly ICountryRepository _countryRepository = new CountryRepository(new DbFactory());
 private readonly IVendorEmployeeRepository _vendoremployeeRepository = new VendorEmployeeRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VendorEmployeeResponseModel> GetVendorEmployees()
        {
                var VendorEmployeeList = (
                                           from _vendoremployee in _vendoremployeeRepository.GetAll()
 join  _vendor in _vendorRepository.GetAll() on  _vendoremployee.VendorId equals _vendor.Id
 join  _city in _cityRepository.GetAll() on  _vendoremployee.Cityid equals _city.Id
 join  _state in _stateRepository.GetAll() on  _vendoremployee.Stateid equals _state.Id
 join  _country in _countryRepository.GetAll() on  _vendoremployee.Countryid equals _country.Id

                                          select new VendorEmployeeResponseModel
                                          {
                                               VendorEmployeeId = _vendoremployee.VendorEmployeeId,
VendorId = _vendor.Id,
vendorName = _vendor.Firstname + " " + _vendor.Lastname,
Id = _vendoremployee.Id,
Firstname = _vendoremployee.Firstname,
Lastname = _vendoremployee.Lastname,
Phoneno = _vendoremployee.Phoneno,
Address1 = _vendoremployee.Address1,
Address2 = _vendoremployee.Address2,
Cityid = _city.Id,
CityName = _city.Name,
Stateid = _state.Id,
StateName = _state.Name,
Countryid = _country.Id,
CountryName = _country.Name,
Modifiedby = _vendoremployee.Modifiedby,
Modifieddate = _vendoremployee.Modifieddate,


                                          }).ToList();
                    return VendorEmployeeList;
            

        }
        public VendorEmployee GetVendorEmployee(int Id)
        {
            var Result = _vendoremployeeRepository.GetById(Id);
            return Result;
        }
        public void CreateVendorEmployee(VendorEmployee VendorEmployeeObj)
        {
            _vendoremployeeRepository.Add(VendorEmployeeObj);
        }
        public void UpdateVendorEmployee(VendorEmployee VendorEmployeeObj)
        {
            _vendoremployeeRepository.Update(VendorEmployeeObj);
        }

        public bool DeleteVendorEmployee(int Id)
        {
            var Result = _vendoremployeeRepository.GetById(Id);
            _vendoremployeeRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetVendorEmployeeDropdown()
        {
            var Result = _vendoremployeeRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.VendorEmployeeId.ToString() ,
                Text = x.Firstname+" "+x.Lastname 

            }).ToList();
            return Result;
        }
         
    }
}
   


