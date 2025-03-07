
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.Vendors;
using VendorService = Data.Vendors.VendorService;


namespace WebUI.Controllers
{
     public class VendorController : Controller
    {
        public readonly ICityService _cityService = new CityService();
public readonly IStateService _stateService = new StateService();
public readonly ICountryService _countryService = new CountryService();
public readonly IVendorService _vendorService = new VendorService();


       public ActionResult List(VendorFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VendorListViewModel Obj = new VendorListViewModel();
                     var VendorList = _vendorService.GetVendors();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.VendorFirstname))
{
 VendorList = VendorList.Where(x => x.Firstname.ToLower().Contains(Filter.VendorFirstname.ToLower())).ToList();
}if(!string.IsNullOrEmpty(Filter.VendorLastname))
{
 VendorList = VendorList.Where(x => x.Lastname.ToLower().Contains(Filter.VendorLastname.ToLower())).ToList();
}if(!string.IsNullOrEmpty(Filter.VendorCompanyname))
{
 VendorList = VendorList.Where(x => x.Companyname.ToLower().Contains(Filter.VendorCompanyname.ToLower())).ToList();
}
                 }
                Obj.List = VendorList;
                 Obj.DropdownCity = _cityService.GetCityDropdown();
 Obj.DropdownState = _stateService.GetStateDropdown();
 Obj.DropdownCountry = _countryService.GetCountryDropdown();

                
                return View(Obj);
		    }
           else
           {
               return RedirectToAction("Login", "Account");
           }
        }
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
			    VendorViewModel Obj = new VendorViewModel();
                 Obj.DropdownCity = _cityService.GetCityDropdown();
 Obj.DropdownState = _stateService.GetStateDropdown();
 Obj.DropdownCountry = _countryService.GetCountryDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Vendor RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _vendorService.CreateVendor(RequestObj);
                 }
                 else
                 {
                     _vendorService.UpdateVendor(RequestObj);
                 }
                 return RedirectToAction("List", "Vendor");
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
         }

        public ActionResult Edit(int Id)
        {
            if (Session["UserId"] != null)
            {
			     var request = _vendorService.GetVendor(Id);
                VendorViewModel Obj = new VendorViewModel()
                {
                    Id= request.Id,
Firstname= request.Firstname,
Lastname= request.Lastname,
Companyname= request.Companyname,
Address1= request.Address1,
Address2= request.Address2,
Cityid= request.Cityid,
Stateid= request.Stateid,
Countryid= request.Countryid,
ModifiedBy= request.ModifiedBy,
ModifiedDate= request.ModifiedDate,

                };
                 Obj.DropdownCity = _cityService.GetCityDropdown();
 Obj.DropdownState = _stateService.GetStateDropdown();
 Obj.DropdownCountry = _countryService.GetCountryDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
           
        }
     
        public ActionResult Delete(int Id)
        {
            if (Session["UserId"] != null)
            {
			  _vendorService.DeleteVendor(Id);
                return RedirectToAction("List", "Vendor");
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
     
    }
}
   


