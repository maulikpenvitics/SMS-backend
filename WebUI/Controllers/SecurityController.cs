
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Residents;
 using Data.Users;
 using Data.Vendors;
 using Data.Securitys;
using VendorService = Data.Vendors.VendorService;


namespace WebUI.Controllers
{
     public class SecurityController : Controller
    {
        public readonly IResidentService _residentService = new ResidentService();
public readonly IUserService _userService = new UserService();
public readonly IVendorService _vendorService = new VendorService();
public readonly ISecurityService _securityService = new SecurityService();


       public ActionResult List(SecurityFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        SecurityListViewModel Obj = new SecurityListViewModel();
                     var SecurityList = _securityService.GetSecuritys();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = SecurityList;
                 Obj.DropdownResident = _residentService.GetResidentDropdown();
 Obj.DropdownUser = _userService.GetUserDropdown();
 Obj.DropdownVendor = _vendorService.GetVendorDropdown();

                
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
			    SecurityViewModel Obj = new SecurityViewModel();
                 Obj.DropdownResident = _residentService.GetResidentDropdown();
 Obj.DropdownUser = _userService.GetUserDropdown();
 Obj.DropdownVendor = _vendorService.GetVendorDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Security RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _securityService.CreateSecurity(RequestObj);
                 }
                 else
                 {
                     _securityService.UpdateSecurity(RequestObj);
                 }
                 return RedirectToAction("List", "Security");
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
			     var request = _securityService.GetSecurity(Id);
                SecurityViewModel Obj = new SecurityViewModel()
                {
                    Id= request.Id,
ResidentId= request.ResidentId,
UserId= request.UserId,
VendorId= request.VendorId,
Incidence= request.Incidence,
Securitydesc= request.Securitydesc,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.DropdownResident = _residentService.GetResidentDropdown();
 Obj.DropdownUser = _userService.GetUserDropdown();
 Obj.DropdownVendor = _vendorService.GetVendorDropdown();

                
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
			  _securityService.DeleteSecurity(Id);
                return RedirectToAction("List", "Security");
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
   


