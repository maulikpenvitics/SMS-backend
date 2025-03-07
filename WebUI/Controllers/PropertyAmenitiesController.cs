
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Propertys;
 using Data.PropertyAmenitiess;


namespace WebUI.Controllers
{
     public class PropertyAmenitiesController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyAmenitiesService _propertyamenitiesService = new PropertyAmenitiesService();


       public ActionResult List(PropertyAmenitiesFilter Filter)
       {
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
           {
		        PropertyAmenitiesListViewModel Obj = new PropertyAmenitiesListViewModel();
                     var PropertyAmenitiesList = _propertyamenitiesService.GetPropertyAmenitiess();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.PropertyAmenitiesAmenityname))
{
 PropertyAmenitiesList = PropertyAmenitiesList.Where(x => x.Amenityname.ToLower().Contains(Filter.PropertyAmenitiesAmenityname.ToLower())).ToList();
}
                 }
                Obj.List = PropertyAmenitiesList;
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
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
            {
			    PropertyAmenitiesViewModel Obj = new PropertyAmenitiesViewModel();
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyAmenities RequestObj)
        {
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyamenitiesService.CreatePropertyAmenities(RequestObj);
                 }
                 else
                 {
                     _propertyamenitiesService.UpdatePropertyAmenities(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyAmenities");
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
			     var request = _propertyamenitiesService.GetPropertyAmenities(Id);
                PropertyAmenitiesViewModel Obj = new PropertyAmenitiesViewModel()
                {
                    Id= request.Id,
PropertyId= request.PropertyId,
Amenityname= request.Amenityname,
Modifiedby= request.Modifiedby,
ModifiedDate= request.ModifiedDate,

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
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
            {
			  _propertyamenitiesService.DeletePropertyAmenities(Id);
                return RedirectToAction("List", "PropertyAmenities");
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
   


