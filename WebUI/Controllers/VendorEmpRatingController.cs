
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.VendorEmployees;
 using Data.VendorEmpRatings;


namespace WebUI.Controllers
{
     public class VendorEmpRatingController : Controller
    {
        public readonly IVendorEmployeeService _vendoremployeeService = new VendorEmployeeService();
public readonly IVendorEmpRatingService _vendorempratingService = new VendorEmpRatingService();


       public ActionResult List(VendorEmpRatingFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VendorEmpRatingListViewModel Obj = new VendorEmpRatingListViewModel();
                     var VendorEmpRatingList = _vendorempratingService.GetVendorEmpRatings();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = VendorEmpRatingList;
                 Obj.DropdownVendorEmployee = _vendoremployeeService.GetVendorEmployeeDropdown();

                
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
			    VendorEmpRatingViewModel Obj = new VendorEmpRatingViewModel();
                 Obj.DropdownVendorEmployee = _vendoremployeeService.GetVendorEmployeeDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(VendorEmpRating RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _vendorempratingService.CreateVendorEmpRating(RequestObj);
                 }
                 else
                 {
                     _vendorempratingService.UpdateVendorEmpRating(RequestObj);
                 }
                 return RedirectToAction("List", "VendorEmpRating");
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
			     var request = _vendorempratingService.GetVendorEmpRating(Id);
                VendorEmpRatingViewModel Obj = new VendorEmpRatingViewModel()
                {
                    Id= request.Id,
Overallrating= request.Overallrating,
VendorEmployeeId= request.VendorEmployeeId,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.DropdownVendorEmployee = _vendoremployeeService.GetVendorEmployeeDropdown();

                
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
			  _vendorempratingService.DeleteVendorEmpRating(Id);
                return RedirectToAction("List", "VendorEmpRating");
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
   


