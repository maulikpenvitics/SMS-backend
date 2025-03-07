
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Propertys;
 using Data.PropertyVendorss;


namespace WebUI.Controllers
{
     public class PropertyVendorsController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyVendorsService _propertyvendorsService = new PropertyVendorsService();


       public ActionResult List(PropertyVendorsFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyVendorsListViewModel Obj = new PropertyVendorsListViewModel();
                     var PropertyVendorsList = _propertyvendorsService.GetPropertyVendorss();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = PropertyVendorsList;
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
			    PropertyVendorsViewModel Obj = new PropertyVendorsViewModel();
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyVendors RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyvendorsService.CreatePropertyVendors(RequestObj);
                 }
                 else
                 {
                     _propertyvendorsService.UpdatePropertyVendors(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyVendors");
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
			     var request = _propertyvendorsService.GetPropertyVendors(Id);
                PropertyVendorsViewModel Obj = new PropertyVendorsViewModel()
                {
                    Id= request.Id,
PropertyId= request.PropertyId,
VendorId= request.VendorId,
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
			  _propertyvendorsService.DeletePropertyVendors(Id);
                return RedirectToAction("List", "PropertyVendors");
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
   


