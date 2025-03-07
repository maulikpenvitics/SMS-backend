
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using Data.States;
using Data.Citys;


namespace WebUI.Controllers
{
    public class CityController : Controller
    {

        public readonly IStateService _stateService = new StateService();
        public readonly ICityService _cityService = new CityService();

        public ActionResult List(CityFilter Filter)
        {
            if (Session["UserId"] != null)
            {
                CityListViewModel Obj = new CityListViewModel();
                var CityList = _cityService.GetCitys();
                if (Filter.FilterSwitch)
                {

                }
                Obj.List = CityList;
                Obj.DropdownState = _stateService.GetStateDropdown();


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
                CityViewModel Obj = new CityViewModel();
                Obj.DropdownState = _stateService.GetStateDropdown();


                return View(Obj);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
        [HttpPost]
        public ActionResult Submit(City RequestObj)
        {
            if (Session["UserId"] != null)
            {
                if (RequestObj.Id == 0)
                {
                    _cityService.CreateCity(RequestObj);
                }
                else
                {
                    _cityService.UpdateCity(RequestObj);
                }
                return RedirectToAction("List", "City");
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
                var request = _cityService.GetCity(Id);
                CityViewModel Obj = new CityViewModel()
                {
                    Id = request.Id,
                    Name = request.Name,
                    StateId = request.StateId
                   

                };
                Obj.DropdownState = _stateService.GetStateDropdown();


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
                _cityService.DeleteCity(Id);
                return RedirectToAction("List", "City");
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



