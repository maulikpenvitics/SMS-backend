
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
 using Data.Users;
 using Data.AmenitiesBookings;


namespace WebUI.Controllers
{
     public class AmenitiesBookingController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
     public readonly IPropertyAmenitiesService _propertyamenitiesService = new PropertyAmenitiesService();
public readonly IUserService _userService = new UserService();
public readonly IAmenitiesBookingService _amenitiesbookingService = new AmenitiesBookingService();


       public ActionResult List(AmenitiesBookingFilter Filter)
       {
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
           {
		        AmenitiesBookingListViewModel Obj = new AmenitiesBookingListViewModel();
                     var AmenitiesBookingList = _amenitiesbookingService.GetAmenitiesBookings();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = AmenitiesBookingList;
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();
 Obj.DropdownUser = _userService.GetUserDropdown();

                
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
			    AmenitiesBookingViewModel Obj = new AmenitiesBookingViewModel();
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

 Obj.DropdownUser = _userService.GetUserDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(AmenitiesBooking RequestObj)
        {
            if (Session["UserId"] != null)
            {
                Session["UserId"] = "1";
                if (RequestObj.Id == 0)
                 {
                    _amenitiesbookingService.CreateAmenitiesBooking(RequestObj);
                 }
                 else
                 {
                     _amenitiesbookingService.UpdateAmenitiesBooking(RequestObj);
                 }
                 return RedirectToAction("List", "AmenitiesBooking");
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
			     var request = _amenitiesbookingService.GetAmenitiesBooking(Id);
                AmenitiesBookingViewModel Obj = new AmenitiesBookingViewModel()
                {
                    Id= request.Id,
PropertyId= request.PropertyId,
PropertyAmenitiesId= request.PropertyAmenitiesId,
UserId= request.UserId,
Amenitiesstatus= request.Amenitiesstatus,
Availabilitytimeslots= request.Availabilitytimeslots,
Bokingpurpose= request.Bokingpurpose,
Checkintime= request.Checkintime,
Checkouttime= request.Checkouttime,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

 Obj.DropdownUser = _userService.GetUserDropdown();

                
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
			  _amenitiesbookingService.DeleteAmenitiesBooking(Id);
                return RedirectToAction("List", "AmenitiesBooking");
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
   


