
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.PropertyOwnerss;


namespace WebUI.Controllers
{
     public class PropertyOwnersController : Controller
    {
        public readonly IPropertyOwnersService _propertyownersService = new PropertyOwnersService();


       public ActionResult List(PropertyOwnersFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyOwnersListViewModel Obj = new PropertyOwnersListViewModel();
                     var PropertyOwnersList = _propertyownersService.GetPropertyOwnerss();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.PropertyOwnersFirstname))
{
 PropertyOwnersList = PropertyOwnersList.Where(x => x.Firstname.ToLower().Contains(Filter.PropertyOwnersFirstname.ToLower())).ToList();
}if(!string.IsNullOrEmpty(Filter.PropertyOwnersLastname))
{
 PropertyOwnersList = PropertyOwnersList.Where(x => x.Lastname.ToLower().Contains(Filter.PropertyOwnersLastname.ToLower())).ToList();
}
                 }
                Obj.List = PropertyOwnersList;
                
                
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
			    PropertyOwnersViewModel Obj = new PropertyOwnersViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyOwners RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyownersService.CreatePropertyOwners(RequestObj);
                 }
                 else
                 {
                     _propertyownersService.UpdatePropertyOwners(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyOwners");
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
			     var request = _propertyownersService.GetPropertyOwners(Id);
                PropertyOwnersViewModel Obj = new PropertyOwnersViewModel()
                {
                    Id= request.Id,
Firstname= request.Firstname,
Lastname= request.Lastname,
Email= request.Email,
Phoneno= request.Phoneno,
BlockId= request.BlockId,
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
			  _propertyownersService.DeletePropertyOwners(Id);
                return RedirectToAction("List", "PropertyOwners");
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
   


