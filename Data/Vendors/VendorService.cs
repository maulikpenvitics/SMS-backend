 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.Vendors;


namespace Data.Vendors
{
     public interface IVendorService
    {
        List<VendorResponseModel> GetVendors();
        Vendor GetVendor(int Id);
        void CreateVendor(Vendor VendorObj);
        void UpdateVendor(Vendor VendorObj);
        bool DeleteVendor(int Id);
        List<SelectListItem> GetVendorDropdown();
         
    }
    public class VendorService : IVendorService
    {
        
         private readonly ICityRepository _cityRepository = new CityRepository(new DbFactory());
 private readonly IStateRepository _stateRepository = new StateRepository(new DbFactory());
 private readonly ICountryRepository _countryRepository = new CountryRepository(new DbFactory());
 private readonly IVendorRepository _vendorRepository = new VendorRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VendorResponseModel> GetVendors()
        {
                var VendorList = (
                                           from _vendor in _vendorRepository.GetAll()
 join  _city in _cityRepository.GetAll() on  _vendor.Cityid equals _city.Id
 join  _state in _stateRepository.GetAll() on  _vendor.Stateid equals _state.Id
 join  _country in _countryRepository.GetAll() on  _vendor.Countryid equals _country.Id

                                          select new VendorResponseModel
                                          {
                                               Id = _vendor.Id,
Firstname = _vendor.Firstname,
Lastname = _vendor.Lastname,
Companyname = _vendor.Companyname,
Address1 = _vendor.Address1,
Address2 = _vendor.Address2,
Cityid = _city.Id,
CityName = _city.Name,
Stateid = _state.Id,
StateName = _state.Name,
Countryid = _country.Id,
CountryName = _country.Name,
ModifiedBy = _vendor.ModifiedBy,
ModifiedDate = _vendor.ModifiedDate,


                                          }).ToList();
                    return VendorList;
            

        }
        public Vendor GetVendor(int Id)
        {
            var Result = _vendorRepository.GetById(Id);
            return Result;
        }
        public void CreateVendor(Vendor VendorObj)
        {
            _vendorRepository.Add(VendorObj);
        }
        public void UpdateVendor(Vendor VendorObj)
        {
            _vendorRepository.Update(VendorObj);
        }

        public bool DeleteVendor(int Id)
        {
            var Result = _vendorRepository.GetById(Id);
            _vendorRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetVendorDropdown()
        {
            var Result = _vendorRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Firstname+" "+x.Lastname

            }).ToList();
            return Result;
        }
         
    }
}
   


