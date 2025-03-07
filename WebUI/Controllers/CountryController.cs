
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Countrys;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
     public class CountryController : Controller
    {
	
        public readonly ICountryService _countryService = new CountryService();
       public ActionResult List(CountryFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        CountryListViewModel Obj = new CountryListViewModel();
                     var CountryList = _countryService.GetCountrys();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = CountryList;
                
                
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
			    CountryViewModel Obj = new CountryViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Country RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _countryService.CreateCountry(RequestObj);
                 }
                 else
                 {
                     _countryService.UpdateCountry(RequestObj);
                 }
                 return RedirectToAction("List", "Country");
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
			     var request = _countryService.GetCountry(Id);
                CountryViewModel Obj = new CountryViewModel()
                {
                    Id= request.Id,

Name= request.Name,


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
			  _countryService.DeleteCountry(Id);
                return RedirectToAction("List", "Country");
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
   


