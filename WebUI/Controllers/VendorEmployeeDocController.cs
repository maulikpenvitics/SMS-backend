
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.VendorEmployeeDocs;


namespace WebUI.Controllers
{
     public class VendorEmployeeDocController : Controller
    {
        public readonly IVendorEmployeeDocService _vendoremployeedocService = new VendorEmployeeDocService();


       public ActionResult List(VendorEmployeeDocFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VendorEmployeeDocListViewModel Obj = new VendorEmployeeDocListViewModel();
                     var VendorEmployeeDocList = _vendoremployeedocService.GetVendorEmployeeDocs();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = VendorEmployeeDocList;
                
                
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
			    VendorEmployeeDocViewModel Obj = new VendorEmployeeDocViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(VendorEmployeeDoc RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _vendoremployeedocService.CreateVendorEmployeeDoc(RequestObj);
                 }
                 else
                 {
                     _vendoremployeedocService.UpdateVendorEmployeeDoc(RequestObj);
                 }
                 return RedirectToAction("List", "VendorEmployeeDoc");
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
			     var request = _vendoremployeedocService.GetVendorEmployeeDoc(Id);
                VendorEmployeeDocViewModel Obj = new VendorEmployeeDocViewModel()
                {
                    Id= request.Id,
Docurl= request.Docurl,
Doctype= request.Doctype,
VendorEmployeeId= request.VendorEmployeeId,
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
			  _vendoremployeedocService.DeleteVendorEmployeeDoc(Id);
                return RedirectToAction("List", "VendorEmployeeDoc");
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
   


