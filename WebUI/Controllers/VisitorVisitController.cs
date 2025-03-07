
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.VisitorVisits;


namespace WebUI.Controllers
{
     public class VisitorVisitController : Controller
    {
        public readonly IVisitorVisitService _visitorvisitService = new VisitorVisitService();


       public ActionResult List(VisitorVisitFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VisitorVisitListViewModel Obj = new VisitorVisitListViewModel();
                     var VisitorVisitList = _visitorvisitService.GetVisitorVisits();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = VisitorVisitList;
                
                
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
			    VisitorVisitViewModel Obj = new VisitorVisitViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(VisitorVisit RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _visitorvisitService.CreateVisitorVisit(RequestObj);
                 }
                 else
                 {
                     _visitorvisitService.UpdateVisitorVisit(RequestObj);
                 }
                 return RedirectToAction("List", "VisitorVisit");
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
			     var request = _visitorvisitService.GetVisitorVisit(Id);
                VisitorVisitViewModel Obj = new VisitorVisitViewModel()
                {
                    Id= request.Id,
VisitorId= request.VisitorId,
Checkin= request.Checkin,
Checkout= request.Checkout,
BlockId= request.BlockId,
Unit= request.Unit,
Gatepass= request.Gatepass,
UserId= request.UserId,
Purpose= request.Purpose,
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
			  _visitorvisitService.DeleteVisitorVisit(Id);
                return RedirectToAction("List", "VisitorVisit");
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
   


