
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using Data.Citys;
using Data.States;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class StateController : Controller
    {

        public readonly ICityService _cityService = new CityService();
        public readonly IStateService _stateService = new StateService();

        public ActionResult List(StateFilter Filter)
        {
            if (Session["UserId"] != null)
            {
                StateListViewModel Obj = new StateListViewModel();
                var StateList = _stateService.GetStates();
                if (Filter.FilterSwitch)
                {

                }
                Obj.List = StateList;
                Obj.DropdownCity = _cityService.GetCityDropdown();


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
                StateViewModel Obj = new StateViewModel();
                Obj.DropdownCity = _cityService.GetCityDropdown();


                return View(Obj);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
        [HttpPost]
        public ActionResult Submit(State RequestObj)
        {
            if (Session["UserId"] != null)
            {
                if (RequestObj.Id == 0)
                {
                    _stateService.CreateState(RequestObj);
                }
                else
                {
                    _stateService.UpdateState(RequestObj);
                }
                return RedirectToAction("List", "State");
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
                var request = _stateService.GetState(Id);
                StateViewModel Obj = new StateViewModel()
                {
                    Id = request.Id,
                    Name = request.Name,
                    CountryId = request.CountryId
                   

                };
                Obj.DropdownCity = _cityService.GetCityDropdown();


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
                _stateService.DeleteState(Id);
                return RedirectToAction("List", "State");
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



