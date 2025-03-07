
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Vendors;
 using Data.Services;
 using Data.VendorServices;


namespace WebUI.Controllers
{
     public class VendorServiceController : Controller
    {
           public readonly IVendorService _vendorService = new Data.Vendors.VendorService();
public readonly IServiceService _serviceService = new ServiceService();
public readonly IVendorServiceService _vendorserviceService = new VendorServiceService();


       public ActionResult List(VendorServiceFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VendorServiceListViewModel Obj = new VendorServiceListViewModel();
                     var VendorServiceList = _vendorserviceService.GetVendorServices();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = VendorServiceList;
                 Obj.Dropdownvendor = _vendorService.GetVendorDropdown();
 Obj.DropdownService = _serviceService.GetServiceDropdown();

                
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
			    VendorServiceViewModel Obj = new VendorServiceViewModel();
                 Obj.Dropdownvendor = _vendorService.GetVendorDropdown();
 Obj.DropdownService = _serviceService.GetServiceDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Domain.Entities.VendorService RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _vendorserviceService.CreateVendorService(RequestObj);
                 }
                 else
                 {
                     _vendorserviceService.UpdateVendorService(RequestObj);
                 }
                 return RedirectToAction("List", "VendorService");
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
			     var request = _vendorserviceService.GetVendorService(Id);
                VendorServiceViewModel Obj = new VendorServiceViewModel()
                {
                    Id= request.Id,
VendorId= request.VendorId,
ServiceId= request.ServiceId,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.Dropdownvendor = _vendorService.GetVendorDropdown();
 Obj.DropdownService = _serviceService.GetServiceDropdown();

                
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
			  _vendorserviceService.DeleteVendorService(Id);
                return RedirectToAction("List", "VendorService");
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
   


