
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
 using Data.Propertys;


namespace WebUI.Controllers
{
     public class PropertyController : Controller
    {
        public readonly ICityService _cityService = new CityService();
public readonly IStateService _stateService = new StateService();
public readonly ICountryService _countryService = new CountryService();
public readonly IPropertyService _propertyService = new PropertyService();


       public ActionResult List(PropertyFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyListViewModel Obj = new PropertyListViewModel();
                     var PropertyList = _propertyService.GetPropertys();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.PropertyPropertyname))
{
 PropertyList = PropertyList.Where(x => x.Propertyname.ToLower().Contains(Filter.PropertyPropertyname.ToLower())).ToList();
}
                 }
                Obj.List = PropertyList;
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
			    PropertyViewModel Obj = new PropertyViewModel();
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
        public ActionResult Submit(Property RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyService.CreateProperty(RequestObj);
                 }
                 else
                 {
                     _propertyService.UpdateProperty(RequestObj);
                 }
                 return RedirectToAction("List", "Property");
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
			     var request = _propertyService.GetProperty(Id);
                PropertyViewModel Obj = new PropertyViewModel()
                {
                    Id= request.Id,
Propertyname= request.Propertyname,
Address1= request.Address1,
Address2= request.Address2,
Cityid= request.Cityid,
Stateid= request.Stateid,
Countryid= request.Countryid,
Zipcode= request.Zipcode,
Phoneno= request.Phoneno,
Email= request.Email,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

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
			  _propertyService.DeleteProperty(Id);
                return RedirectToAction("List", "Property");
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
   


