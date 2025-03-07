
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Vendors;
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.VendorEmployees;


namespace WebUI.Controllers
{
     public class VendorEmployeeController : Controller
    {
        public readonly IVendorService _VendorService = new Data.Vendors.VendorService();
public readonly ICityService _cityService = new CityService();
public readonly IStateService _stateService = new StateService();
public readonly ICountryService _countryService = new CountryService();
public readonly IVendorEmployeeService _VendoremployeeService = new VendorEmployeeService();


       public ActionResult List(VendorEmployeeFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VendorEmployeeListViewModel Obj = new VendorEmployeeListViewModel();
                     var VendorEmployeeList = _VendoremployeeService.GetVendorEmployees();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = VendorEmployeeList;
                 Obj.Dropdownvendor = _VendorService.GetVendorDropdown();
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
			    VendorEmployeeViewModel Obj = new VendorEmployeeViewModel();
                 Obj.Dropdownvendor = _VendorService.GetVendorDropdown();
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
        public ActionResult Submit(VendorEmployee RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.VendorEmployeeId == 0)
                 {
                    _VendoremployeeService.CreateVendorEmployee(RequestObj);
                 }
                 else
                 {
                     _VendoremployeeService.UpdateVendorEmployee(RequestObj);
                 }
                 return RedirectToAction("List", "VendorEmployee");
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
			     var request = _VendoremployeeService.GetVendorEmployee(Id);
                VendorEmployeeViewModel Obj = new VendorEmployeeViewModel()
                {
                    VendorEmployeeId= request.VendorEmployeeId,
VendorId= request.VendorId,
Id= request.Id,
Firstname= request.Firstname,
Lastname= request.Lastname,
Phoneno= request.Phoneno,
Address1= request.Address1,
Address2= request.Address2,
Cityid= request.Cityid,
Stateid= request.Stateid,
Countryid= request.Countryid,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                        Obj.Dropdownvendor = _VendorService.GetVendorDropdown();
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
			  _VendoremployeeService.DeleteVendorEmployee(Id);
                return RedirectToAction("List", "VendorEmployee");
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
   


