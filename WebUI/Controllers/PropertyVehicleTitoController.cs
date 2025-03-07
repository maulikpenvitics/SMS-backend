
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.PropertyVehicles;
 using Data.PropertyVehicleTitos;


namespace WebUI.Controllers
{
     public class PropertyVehicleTitoController : Controller
    {
        public readonly IPropertyVehicleService _propertyvehicleService = new PropertyVehicleService();
public readonly IPropertyVehicleTitoService _propertyvehicletitoService = new PropertyVehicleTitoService();


       public ActionResult List(PropertyVehicleTitoFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyVehicleTitoListViewModel Obj = new PropertyVehicleTitoListViewModel();
                     var PropertyVehicleTitoList = _propertyvehicletitoService.GetPropertyVehicleTitos();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = PropertyVehicleTitoList;
              

                
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
			    PropertyVehicleTitoViewModel Obj = new PropertyVehicleTitoViewModel();
                

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyVehicleTito RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyvehicletitoService.CreatePropertyVehicleTito(RequestObj);
                 }
                 else
                 {
                     _propertyvehicletitoService.UpdatePropertyVehicleTito(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyVehicleTito");
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
			     var request = _propertyvehicletitoService.GetPropertyVehicleTito(Id);
                PropertyVehicleTitoViewModel Obj = new PropertyVehicleTitoViewModel()
                {
                    Id= request.Id,
PropertyVehicleId= request.PropertyVehicleId,
Checkintime= request.Checkintime,
Checkouttime= request.Checkouttime,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                

                
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
			  _propertyvehicletitoService.DeletePropertyVehicleTito(Id);
                return RedirectToAction("List", "PropertyVehicleTito");
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
   


