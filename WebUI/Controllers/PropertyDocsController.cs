
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Propertys;
 using Data.PropertyDocss;
using Data.Users;
using Data.Units;


namespace WebUI.Controllers
{
     public class PropertyDocsController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyDocsService _propertydocsService = new PropertyDocsService();
        public readonly IUserService _userService = new UserService();
        public readonly IUnitService _unitService = new UnitService();


       public ActionResult List(PropertyDocsFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyDocsListViewModel Obj = new PropertyDocsListViewModel();
                     var PropertyDocsList = _propertydocsService.GetPropertyDocss();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = PropertyDocsList;
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();


                
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
			    PropertyDocsViewModel Obj = new PropertyDocsViewModel();
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyDocs RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertydocsService.CreatePropertyDocs(RequestObj);
                 }
                 else
                 {
                     _propertydocsService.UpdatePropertyDocs(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyDocs");
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
			     var request = _propertydocsService.GetPropertyDocs(Id);
                PropertyDocsViewModel Obj = new PropertyDocsViewModel()
                {
                    Id= request.Id,
PropertyId= request.PropertyId,
UserId= request.UserId,
Docurl= request.Docurl,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();


                
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
			  _propertydocsService.DeletePropertyDocs(Id);
                return RedirectToAction("List", "PropertyDocs");
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
   


