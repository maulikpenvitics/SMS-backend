
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;

using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Vendors;
 using Data.VendorInvoices;


namespace WebUI.Controllers
{
     public class VendorInvoiceController : Controller
    {
            public readonly IVendorService _vendorService = new Data.Vendors.VendorService();
public readonly IVendorInvoiceService _vendorinvoiceService = new VendorInvoiceService();


       public ActionResult List(VendorInvoiceFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VendorInvoiceListViewModel Obj = new VendorInvoiceListViewModel();
                     var VendorInvoiceList = _vendorinvoiceService.GetVendorInvoices();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = VendorInvoiceList;
                 Obj.Dropdownvendor = _vendorService.GetVendorDropdown();

                
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
			    VendorInvoiceViewModel Obj = new VendorInvoiceViewModel();
                 Obj.Dropdownvendor = _vendorService.GetVendorDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(VendorInvoice RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _vendorinvoiceService.CreateVendorInvoice(RequestObj);
                 }
                 else
                 {
                     _vendorinvoiceService.UpdateVendorInvoice(RequestObj);
                 }
                 return RedirectToAction("List", "VendorInvoice");
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
			     var request = _vendorinvoiceService.GetVendorInvoice(Id);
                VendorInvoiceViewModel Obj = new VendorInvoiceViewModel()
                {
                    Id= request.Id,
VendorId= request.VendorId,
Invoicedate= request.Invoicedate,
Todate= request.Todate,
Amount= request.Amount,
Duedate= request.Duedate,
Tax= request.Tax,
NetAmount= request.NetAmount,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.Dropdownvendor = _vendorService.GetVendorDropdown();

                
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
			  _vendorinvoiceService.DeleteVendorInvoice(Id);
                return RedirectToAction("List", "VendorInvoice");
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
   


