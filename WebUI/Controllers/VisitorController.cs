
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Visitors;


namespace WebUI.Controllers
{
     public class VisitorController : Controller
    {
        public readonly IVisitorService _visitorService = new VisitorService();


       public ActionResult List(VisitorFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        VisitorListViewModel Obj = new VisitorListViewModel();
                     var VisitorList = _visitorService.GetVisitors();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.VisitorIdno.ToString()))
{
 VisitorList = VisitorList.Where(x => x.Idno == Filter.VisitorIdno).ToList();
}if(!string.IsNullOrEmpty(Filter.VisitorGatepass.ToString()))
{
 VisitorList = VisitorList.Where(x => x.Gatepass == Filter.VisitorGatepass).ToList();
}if(!string.IsNullOrEmpty(Filter.VisitorPhoneno.ToString()))
{
 VisitorList = VisitorList.Where(x => x.Phoneno == Filter.VisitorPhoneno).ToList();
}
                 }
                Obj.List = VisitorList;
                
                
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
			    VisitorViewModel Obj = new VisitorViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Visitor RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _visitorService.CreateVisitor(RequestObj);
                 }
                 else
                 {
                     _visitorService.UpdateVisitor(RequestObj);
                 }
                 return RedirectToAction("List", "Visitor");
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
			     var request = _visitorService.GetVisitor(Id);
                VisitorViewModel Obj = new VisitorViewModel()
                {
                    Id= request.Id,
Firstname= request.Firstname,
Lastname= request.Lastname,
Idno= request.Idno,
Idtype= request.Idtype,
Gatepass= request.Gatepass,
Phoneno= request.Phoneno,
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
			  _visitorService.DeleteVisitor(Id);
                return RedirectToAction("List", "Visitor");
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
   


