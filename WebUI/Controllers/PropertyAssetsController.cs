
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Propertys;
 using Data.PropertyAssetss;


namespace WebUI.Controllers
{
     public class PropertyAssetsController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyAssetsService _propertyassetsService = new PropertyAssetsService();


       public ActionResult List(PropertyAssetsFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyAssetsListViewModel Obj = new PropertyAssetsListViewModel();
                     var PropertyAssetsList = _propertyassetsService.GetPropertyAssetss();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.PropertyAssetsAssetname))
{
 PropertyAssetsList = PropertyAssetsList.Where(x => x.Assetname.ToLower().Contains(Filter.PropertyAssetsAssetname.ToLower())).ToList();
}
                 }
                Obj.List = PropertyAssetsList;
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
			    PropertyAssetsViewModel Obj = new PropertyAssetsViewModel();
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyAssets RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyassetsService.CreatePropertyAssets(RequestObj);
                 }
                 else
                 {
                     _propertyassetsService.UpdatePropertyAssets(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyAssets");
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
			     var request = _propertyassetsService.GetPropertyAssets(Id);
                PropertyAssetsViewModel Obj = new PropertyAssetsViewModel()
                {
                    Id= request.Id,
PropertyId= request.PropertyId,
Assetname= request.Assetname,
Assetnumber= request.Assetnumber,
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
			  _propertyassetsService.DeletePropertyAssets(Id);
                return RedirectToAction("List", "PropertyAssets");
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
   


