
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Propertys;
 using Data.PropertyVehicles;


namespace WebUI.Controllers
{
     public class PropertyVehicleController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyVehicleService _propertyvehicleService = new PropertyVehicleService();


       public ActionResult List(PropertyVehicleFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyVehicleListViewModel Obj = new PropertyVehicleListViewModel();
                     var PropertyVehicleList = _propertyvehicleService.GetPropertyVehicles();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = PropertyVehicleList;
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
			    PropertyVehicleViewModel Obj = new PropertyVehicleViewModel();
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyVehicle RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyvehicleService.CreatePropertyVehicle(RequestObj);
                 }
                 else
                 {
                     _propertyvehicleService.UpdatePropertyVehicle(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyVehicle");
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
			     var request = _propertyvehicleService.GetPropertyVehicle(Id);
                PropertyVehicleViewModel Obj = new PropertyVehicleViewModel()
                {
                    Id= request.Id,
PropertyId= request.PropertyId,
Vehiclenumber= request.Vehiclenumber,
Model= request.Model,
PropertyOwnersId= request.PropertyOwnersId,
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
			  _propertyvehicleService.DeletePropertyVehicle(Id);
                return RedirectToAction("List", "PropertyVehicle");
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
   


