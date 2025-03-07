
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.VendorInvoiceDetails;


namespace WebUI.Controllers
{
     public class VendorInvoiceDetailController : Controller
    {
        public readonly IVendorInvoiceDetailService _vendorinvoicedetailService = new VendorInvoiceDetailService();


       public ActionResult List(VendorInvoiceDetailFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VendorInvoiceDetailListViewModel Obj = new VendorInvoiceDetailListViewModel();
                     var VendorInvoiceDetailList = _vendorinvoicedetailService.GetVendorInvoiceDetails();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = VendorInvoiceDetailList;
                
                
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
			    VendorInvoiceDetailViewModel Obj = new VendorInvoiceDetailViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(VendorInvoiceDetail RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _vendorinvoicedetailService.CreateVendorInvoiceDetail(RequestObj);
                 }
                 else
                 {
                     _vendorinvoicedetailService.UpdateVendorInvoiceDetail(RequestObj);
                 }
                 return RedirectToAction("List", "VendorInvoiceDetail");
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
			     var request = _vendorinvoicedetailService.GetVendorInvoiceDetail(Id);
                VendorInvoiceDetailViewModel Obj = new VendorInvoiceDetailViewModel()
                {
                    Id= request.Id,
VendorInvoiceId= request.VendorInvoiceId,
Lineitem= request.Lineitem,
Amount= request.Amount,
Description= request.Description,
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
			  _vendorinvoicedetailService.DeleteVendorInvoiceDetail(Id);
                return RedirectToAction("List", "VendorInvoiceDetail");
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
   


