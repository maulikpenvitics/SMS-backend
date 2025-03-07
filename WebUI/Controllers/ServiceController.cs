
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Services;


namespace WebUI.Controllers
{
     public class ServiceController : Controller
    {
        public readonly IServiceService _serviceService = new ServiceService();


       public ActionResult List(ServiceFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        ServiceListViewModel Obj = new ServiceListViewModel();
                     var ServiceList = _serviceService.GetServices();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = ServiceList;
                
                
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
			    ServiceViewModel Obj = new ServiceViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Service RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _serviceService.CreateService(RequestObj);
                 }
                 else
                 {
                     _serviceService.UpdateService(RequestObj);
                 }
                 return RedirectToAction("List", "Service");
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
			     var request = _serviceService.GetService(Id);
                ServiceViewModel Obj = new ServiceViewModel()
                {
                    Id= request.Id,
Name= request.Name,
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
			  _serviceService.DeleteService(Id);
                return RedirectToAction("List", "Service");
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
   


