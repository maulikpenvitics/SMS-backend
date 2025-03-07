
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Visitors;
 using Data.Directorys;


namespace WebUI.Controllers
{
     public class DirectoryController : Controller
    {
        public readonly IVisitorService _visitorService = new VisitorService();
public readonly IDirectoryService _directoryService = new DirectoryService();


       public ActionResult List(DirectoryFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        DirectoryListViewModel Obj = new DirectoryListViewModel();
                     var DirectoryList = _directoryService.GetDirectorys();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = DirectoryList;
                 Obj.DropdownVisitor = _visitorService.GetVisitorDropdown();

                
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
			    DirectoryViewModel Obj = new DirectoryViewModel();
                 Obj.DropdownVisitor = _visitorService.GetVisitorDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Directory RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _directoryService.CreateDirectory(RequestObj);
                 }
                 else
                 {
                     _directoryService.UpdateDirectory(RequestObj);
                 }
                 return RedirectToAction("List", "Directory");
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
			     var request = _directoryService.GetDirectory(Id);
                DirectoryViewModel Obj = new DirectoryViewModel()
                {
                    Id= request.Id,
Discription= request.Discription,
Bussinessid= request.Bussinessid,
VisitorId= request.VisitorId,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.DropdownVisitor = _visitorService.GetVisitorDropdown();

                
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
			  _directoryService.DeleteDirectory(Id);
                return RedirectToAction("List", "Directory");
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
   


