
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using Data.Reportss;
using Data.Propertys;


namespace WebUI.Controllers
{
    public class ReportsController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
        //public readonly IReportsService _reportsService = new ReportsService();

        public ActionResult List(ReportsFilter Filter)
        {
            if (Session["UserId"] != null)
            {

                var propertyList = _propertyService.GetPropertys();
                return View(propertyList);
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
                ReportsViewModel Obj = new ReportsViewModel();


                return View(Obj);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
        [HttpPost]
        public ActionResult Submit(Property RequestObj)
        {
            if (Session["UserId"] != null)
            {
                if (RequestObj.Id == 0)
                {
                    _propertyService.CreateProperty(RequestObj);
                }
                else
                {
                    _propertyService.UpdateProperty(RequestObj);
                }
                return RedirectToAction("List", "Reports");
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
                var request = _propertyService.GetProperty(Id);
                ReportsViewModel Obj = new ReportsViewModel()
                {
                    Id = request.Id,
                    Name = request.Propertyname,
                    Modifiedby = request.Modifiedby,
                    Modifieddate = request.Modifieddate,

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
                _propertyService.DeleteProperty(Id);
                return RedirectToAction("List", "Reports");
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



