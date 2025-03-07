
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Propertys;
 using Data.Vendors;
 using Data.Accountings;
using VendorService = Data.Vendors.VendorService;
using Data.Users;


namespace WebUI.Controllers
{
   public class AccountingController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IVendorService _vendorService = new VendorService();
public readonly IAccountingService _accountingService = new AccountingService();
        public readonly IUserService _userService = new UserService();


       public ActionResult List(AccountingFilter Filter)
       {
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
           {
                
                AccountingListViewModel Obj = new AccountingListViewModel();
                     var AccountingList = _accountingService.GetAccountings();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.AccountingAccountname))
{
 AccountingList = AccountingList.Where(x => x.Accountname.ToLower().Contains(Filter.AccountingAccountname.ToLower())).ToList();
}
                 }
                Obj.List = AccountingList;
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();
 Obj.DropdownVendor = _vendorService.GetVendorDropdown();

                
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
			    AccountingViewModel Obj = new AccountingViewModel();
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();
 Obj.DropdownVendor = _vendorService.GetVendorDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Accounting RequestObj)
        {
            Session["UserId"] = "1";
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _accountingService.CreateAccounting(RequestObj);
                 }
                 else
                 {
                     _accountingService.UpdateAccounting(RequestObj);
                 }
                 return RedirectToAction("List", "Accounting");
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
			     var request = _accountingService.GetAccounting(Id);
                AccountingViewModel Obj = new AccountingViewModel()
                {
                    Id= request.Id,
Accountname= request.Accountname,
UserId= request.UserId,
PropertyId= request.PropertyId,
VendorId= request.VendorId,
Accountid= request.Accountid,
Accountno= request.Accountno,
Balance= request.Balance,
Entitytype= request.Entitytype,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();
 Obj.DropdownVendor = _vendorService.GetVendorDropdown();

                
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
			  _accountingService.DeleteAccounting(Id);
                return RedirectToAction("List", "Accounting");
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
   


