
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Propertys;
 using Data.PropertyAdvertisements;


namespace WebUI.Controllers
{
     public class PropertyAdvertisementController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyAdvertisementService _propertyadvertisementService = new PropertyAdvertisementService();


       public ActionResult List(PropertyAdvertisementFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyAdvertisementListViewModel Obj = new PropertyAdvertisementListViewModel();
                     var PropertyAdvertisementList = _propertyadvertisementService.GetPropertyAdvertisements();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = PropertyAdvertisementList;
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
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
			    PropertyAdvertisementViewModel Obj = new PropertyAdvertisementViewModel();
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyAdvertisement RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyadvertisementService.CreatePropertyAdvertisement(RequestObj);
                 }
                 else
                 {
                     _propertyadvertisementService.UpdatePropertyAdvertisement(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyAdvertisement");
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
			     var request = _propertyadvertisementService.GetPropertyAdvertisement(Id);
                PropertyAdvertisementViewModel Obj = new PropertyAdvertisementViewModel()
                {
                    Id= request.Id,
PropertyId= request.PropertyId,
Location= request.Location,
Fromdate= request.Fromdate,
Todate= request.Todate,
Amount= request.Amount,
Companyname= request.Companyname,
Advertisorfirstname= request.Advertisorfirstname,
Advertisorlastname= request.Advertisorlastname,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
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
			  _propertyadvertisementService.DeletePropertyAdvertisement(Id);
                return RedirectToAction("List", "PropertyAdvertisement");
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
   


