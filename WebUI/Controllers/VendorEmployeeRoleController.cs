
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.VendorEmployeeRoles;


namespace WebUI.Controllers
{
     public class VendorEmployeeRoleController : Controller
    {
        public readonly IVendorEmployeeRoleService _vendoremployeeroleService = new VendorEmployeeRoleService();


       public ActionResult List(VendorEmployeeRoleFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VendorEmployeeRoleListViewModel Obj = new VendorEmployeeRoleListViewModel();
                     var VendorEmployeeRoleList = _vendoremployeeroleService.GetVendorEmployeeRoles();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = VendorEmployeeRoleList;
                
                
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
			    VendorEmployeeRoleViewModel Obj = new VendorEmployeeRoleViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(VendorEmployeeRole RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _vendoremployeeroleService.CreateVendorEmployeeRole(RequestObj);
                 }
                 else
                 {
                     _vendoremployeeroleService.UpdateVendorEmployeeRole(RequestObj);
                 }
                 return RedirectToAction("List", "VendorEmployeeRole");
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
			     var request = _vendoremployeeroleService.GetVendorEmployeeRole(Id);
                VendorEmployeeRoleViewModel Obj = new VendorEmployeeRoleViewModel()
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
			  _vendoremployeeroleService.DeleteVendorEmployeeRole(Id);
                return RedirectToAction("List", "VendorEmployeeRole");
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
   


