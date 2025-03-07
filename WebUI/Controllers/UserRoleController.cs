
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;

using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Users;
 using Data.Roles;
 using Data.UserRoles;


namespace WebUI.Controllers
{
     public class UserRoleController : Controller
    {
                 public readonly IUserService _userService = new UserService();
public readonly IRoleService _roleService = new RoleService();
public readonly IUserRoleService _userroleService = new UserRoleService();


       public ActionResult List(UserRoleFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        UserRoleListViewModel Obj = new UserRoleListViewModel();
                     var UserRoleList = _userroleService.GetUserRoles();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = UserRoleList;
                 Obj.Dropdownuser = _userService.GetUserDropdown();
 Obj.Dropdownrole = _roleService.GetRoleDropdown();

                
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
			    UserRoleViewModel Obj = new UserRoleViewModel();
                 Obj.Dropdownuser = _userService.GetUserDropdown();
 Obj.Dropdownrole = _roleService.GetRoleDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(UserRole RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _userroleService.CreateUserRole(RequestObj);
                 }
                 else
                 {
                     _userroleService.UpdateUserRole(RequestObj);
                 }
                 return RedirectToAction("List", "UserRole");
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
			     var request = _userroleService.GetUserRole(Id);
                UserRoleViewModel Obj = new UserRoleViewModel()
                {
                    Id= request.Id,
UserId= request.UserId,
RoleId= request.RoleId,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.Dropdownuser = _userService.GetUserDropdown();
 Obj.Dropdownrole = _roleService.GetRoleDropdown();

                
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
			  _userroleService.DeleteUserRole(Id);
                return RedirectToAction("List", "UserRole");
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
   


