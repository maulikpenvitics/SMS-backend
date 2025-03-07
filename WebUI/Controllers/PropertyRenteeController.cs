
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.PropertyRentees;


namespace WebUI.Controllers
{
     public class PropertyRenteeController : Controller
    {
        public readonly IPropertyRenteeService _propertyrenteeService = new PropertyRenteeService();


       public ActionResult List(PropertyRenteeFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyRenteeListViewModel Obj = new PropertyRenteeListViewModel();
                     var PropertyRenteeList = _propertyrenteeService.GetPropertyRentees();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.PropertyRenteeFirstname))
{
 PropertyRenteeList = PropertyRenteeList.Where(x => x.Firstname.ToLower().Contains(Filter.PropertyRenteeFirstname.ToLower())).ToList();
}if(!string.IsNullOrEmpty(Filter.PropertyRenteeLastname))
{
 PropertyRenteeList = PropertyRenteeList.Where(x => x.Lastname.ToLower().Contains(Filter.PropertyRenteeLastname.ToLower())).ToList();
}
                 }
                Obj.List = PropertyRenteeList;
                
                
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
			    PropertyRenteeViewModel Obj = new PropertyRenteeViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyRentee RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyrenteeService.CreatePropertyRentee(RequestObj);
                 }
                 else
                 {
                     _propertyrenteeService.UpdatePropertyRentee(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyRentee");
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
			     var request = _propertyrenteeService.GetPropertyRentee(Id);
                PropertyRenteeViewModel Obj = new PropertyRenteeViewModel()
                {
                    Id= request.Id,
Firstname= request.Firstname,
Lastname= request.Lastname,
Email= request.Email,
Phoneno= request.Phoneno,
BlockId= request.BlockId,
Unitno= request.Unitno,
Profession= request.Profession,
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
			  _propertyrenteeService.DeletePropertyRentee(Id);
                return RedirectToAction("List", "PropertyRentee");
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
   


