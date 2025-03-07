
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Roles;


namespace WebUI.Controllers
{
     public class RoleController : Controller
    {
        public readonly IRoleService _roleService = new RoleService();


       public ActionResult List(RoleFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        RoleListViewModel Obj = new RoleListViewModel();
                     var RoleList = _roleService.GetRoles();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = RoleList;
                
                
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
			    RoleViewModel Obj = new RoleViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Role RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _roleService.CreateRole(RequestObj);
                 }
                 else
                 {
                     _roleService.UpdateRole(RequestObj);
                 }
                 return RedirectToAction("List", "Role");
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
			     var request = _roleService.GetRole(Id);
                RoleViewModel Obj = new RoleViewModel()
                {
                    Id= request.Id,
Name= request.Name,
ModifiedBy= request.ModifiedBy,
ModifiedDate= request.ModifiedDate,

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
			  _roleService.DeleteRole(Id);
                return RedirectToAction("List", "Role");
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
   


