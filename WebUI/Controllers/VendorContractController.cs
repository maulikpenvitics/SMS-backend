
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Vendors;
 using Data.VendorContracts;


namespace WebUI.Controllers
{
     public class VendorContractController : Controller
    {
           public readonly IVendorService _Vendorservice = new Data.Vendors.VendorService();
public readonly IVendorContractService _vendorcontractService = new VendorContractService();


       public ActionResult List(VendorContractFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VendorContractListViewModel Obj = new VendorContractListViewModel();
                     var VendorContractList = _vendorcontractService.GetVendorContracts();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = VendorContractList;
                 Obj.Dropdownvendor = _Vendorservice.GetVendorDropdown();

                
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
			    VendorContractViewModel Obj = new VendorContractViewModel();
                 Obj.Dropdownvendor = _Vendorservice.GetVendorDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(VendorContract RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _vendorcontractService.CreateVendorContract(RequestObj);
                 }
                 else
                 {
                     _vendorcontractService.UpdateVendorContract(RequestObj);
                 }
                 return RedirectToAction("List", "VendorContract");
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
			     var request = _vendorcontractService.GetVendorContract(Id);
                VendorContractViewModel Obj = new VendorContractViewModel()
                {
                    Id= request.Id,
VendorId= request.VendorId,
Contracturl= request.Contracturl,
Fromdate= request.Fromdate,
Todate= request.Todate,
Amount= request.Amount,
Paymentcycle= request.Paymentcycle,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.Dropdownvendor = _Vendorservice.GetVendorDropdown();

                
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
			  _vendorcontractService.DeleteVendorContract(Id);
                return RedirectToAction("List", "VendorContract");
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
   


