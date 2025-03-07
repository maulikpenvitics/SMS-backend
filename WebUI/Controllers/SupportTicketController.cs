
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Services;
 using Data.Vendors;
 using Data.SupportTickets;
using Data.Users;


namespace WebUI.Controllers
{
     public class SupportTicketController : Controller
    {
           public readonly IServiceService _serviceService = new ServiceService();
public readonly IVendorService _Vendorservice = new Data.Vendors.VendorService();
public readonly ISupportTicketService _supportticketService = new SupportTicketService();
        public readonly IUserService _userService = new UserService();


       public ActionResult List(SupportTicketFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        SupportTicketListViewModel Obj = new SupportTicketListViewModel();
                     var SupportTicketList = _supportticketService.GetSupportTickets();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = SupportTicketList;
                 Obj.Dropdownservice = _serviceService.GetServiceDropdown();
                 Obj.Dropdownvendor = _Vendorservice.GetVendorDropdown();

                
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
			    SupportTicketViewModel Obj = new SupportTicketViewModel();
                 Obj.Dropdownservice = _serviceService.GetServiceDropdown();
 Obj.Dropdownvendor = _Vendorservice.GetVendorDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(SupportTicket RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _supportticketService.CreateSupportTicket(RequestObj);
                 }
                 else
                 {
                     _supportticketService.UpdateSupportTicket(RequestObj);
                 }
                 return RedirectToAction("List", "SupportTicket");
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
			     var request = _supportticketService.GetSupportTicket(Id);
                SupportTicketViewModel Obj = new SupportTicketViewModel()
                {
                    Id= request.Id,
                    UserId= request.UserId,
Ticket= request.Ticket,
Description= request.Description,
Severity= request.Severity,
Duedate= request.Duedate,
ServiceId= request.ServiceId,
Status= request.Status,
Comment= request.Comment,
VendorEmployeeId= request.VendorEmployeeId,
VendorId= request.VendorId,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.Dropdownservice = _serviceService.GetServiceDropdown();
 Obj.Dropdownvendor = _Vendorservice.GetVendorDropdown();

                
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
			  _supportticketService.DeleteSupportTicket(Id);
                return RedirectToAction("List", "SupportTicket");
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
   


