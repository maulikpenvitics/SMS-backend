
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;

using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Propertys;
 using Data.Roles;
 using Data.Users;
using Data;


namespace WebUI.Controllers
{
     public class UserController : Controller
    {
            public readonly IPropertyService _propertyService = new PropertyService();
public readonly IRoleService _roleService = new RoleService();
public readonly IUserService _userService = new UserService();

       // Session["UserId"] = "1";

       public ActionResult List(UserFilter Filter)
       {
            Session["UserId"] = "1";

            if (Session["UserId"] != null)
           {
		        UserListViewModel Obj = new UserListViewModel();
                     var UserList = _userService.GetUsers();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.UserPassword.ToString()))
{
 UserList = UserList.Where(x => x.Password == Filter.UserPassword).ToList();
}if(!string.IsNullOrEmpty(Filter.UserPhone.ToString()))
{
 UserList = UserList.Where(x => x.Phone == Filter.UserPhone).ToList();
}
                 }
                Obj.List = UserList;
                 Obj.Dropdownproperty = _propertyService.GetPropertyDropdown();
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
            Session["UserId"] = "1";


            if (Session["UserId"] != null)
            {
			    UserViewModel Obj = new UserViewModel();
                 Obj.Dropdownproperty = _propertyService.GetPropertyDropdown();
 Obj.Dropdownrole = _roleService.GetRoleDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(User RequestObj)
        {
            Session["UserId"] = "1";

            if (Session["UserId"] != null)
            {
                               
			     if (RequestObj.Id == 0)
                 {
                    _userService.CreateUser(RequestObj);
                 }
                 else
                 {
                     _userService.UpdateUser(RequestObj);
                 }
                 return RedirectToAction("List", "User");
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
			     var request = _userService.GetUser(Id);
                UserViewModel Obj = new UserViewModel()
                {
                    Id= request.Id,
Username= request.Username,
Password= request.Password,
Firstname= request.Firstname,
Lastname= request.Lastname,
Email= request.Email,
Phone= request.Phone,
PropertyId= request.PropertyId,
RoleId= request.RoleId,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.Dropdownproperty = _propertyService.GetPropertyDropdown();
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
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
            {
			  _userService.DeleteUser(Id);
                return RedirectToAction("List", "User");
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
   


