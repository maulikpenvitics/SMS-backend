
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.PropertyRentees;
 using Data.PropertyRenteeAgreements;


namespace WebUI.Controllers
{
     public class PropertyRenteeAgreementController : Controller
    {
        public readonly IPropertyRenteeService _propertyrenteeService = new PropertyRenteeService();
public readonly IPropertyRenteeAgreementService _propertyrenteeagreementService = new PropertyRenteeAgreementService();


       public ActionResult List(PropertyRenteeAgreementFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        PropertyRenteeAgreementListViewModel Obj = new PropertyRenteeAgreementListViewModel();
                     var PropertyRenteeAgreementList = _propertyrenteeagreementService.GetPropertyRenteeAgreements();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = PropertyRenteeAgreementList;
                 Obj.DropdownPropertyRentee = _propertyrenteeService.GetPropertyRenteeDropdown();

                
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
			    PropertyRenteeAgreementViewModel Obj = new PropertyRenteeAgreementViewModel();
                 Obj.DropdownPropertyRentee = _propertyrenteeService.GetPropertyRenteeDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(PropertyRenteeAgreement RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _propertyrenteeagreementService.CreatePropertyRenteeAgreement(RequestObj);
                 }
                 else
                 {
                     _propertyrenteeagreementService.UpdatePropertyRenteeAgreement(RequestObj);
                 }
                 return RedirectToAction("List", "PropertyRenteeAgreement");
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
			     var request = _propertyrenteeagreementService.GetPropertyRenteeAgreement(Id);
                PropertyRenteeAgreementViewModel Obj = new PropertyRenteeAgreementViewModel()
                {
                    Id= request.Id,
PropertyId= request.PropertyId,
BlockId= request.BlockId,
Unitid= request.Unitid,
Agreementurl= request.Agreementurl,
PropertyRenteeId= request.PropertyRenteeId,
Agreementstartdate= request.Agreementstartdate,
Agreementenddate= request.Agreementenddate,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.DropdownPropertyRentee = _propertyrenteeService.GetPropertyRenteeDropdown();

                
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
			  _propertyrenteeagreementService.DeletePropertyRenteeAgreement(Id);
                return RedirectToAction("List", "PropertyRenteeAgreement");
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
   


