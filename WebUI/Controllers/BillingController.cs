
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Billings;


namespace WebUI.Controllers
{
     public class BillingController : Controller
    {
        public readonly IBillingService _billingService = new BillingService();


       public ActionResult List(BillingFilter Filter)
       {
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
           {
		        BillingListViewModel Obj = new BillingListViewModel();
                     var BillingList = _billingService.GetBillings();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = BillingList;
                
                
                return View(Obj);
		    }
           else
           {
               return RedirectToAction("Login", "Account");
           }
        }
        public ActionResult Create()
        {
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
            {
			    BillingViewModel Obj = new BillingViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Billing RequestObj)
        {
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _billingService.CreateBilling(RequestObj);
                 }
                 else
                 {
                     _billingService.UpdateBilling(RequestObj);
                 }
                 return RedirectToAction("List", "Billing");
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
         }

        public ActionResult Edit(int Id)
        {
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
            {
			     var request = _billingService.GetBilling(Id);
                BillingViewModel Obj = new BillingViewModel()
                {
                    Id= request.Id,
Debitaccountid= request.Debitaccountid,
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
			  _billingService.DeleteBilling(Id);
                return RedirectToAction("List", "Billing");
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
   


