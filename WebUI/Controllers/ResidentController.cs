using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using Data.Propertys;
using Data.Blocks;
using Data.Residents;
using Data.Units;

namespace WebUI.Controllers
{
    public class ResidentController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
        public readonly IBlockService _blockService = new BlockService();
        public readonly IResidentService _residentService = new ResidentService();
        public readonly IUnitService _unitService = new UnitService();

        public ActionResult List(ResidentFilter Filter)
        {
            if (Session["UserId"] != null)
            {
                ResidentListViewModel Obj = new ResidentListViewModel();
                var ResidentList = _residentService.GetResidents();
                if (Filter.FilterSwitch)
                {
                    if (!string.IsNullOrEmpty(Filter.ResidentPassword?.ToString()))
                    {
                        ResidentList = ResidentList.Where(x => x.Password == Filter.ResidentPassword).ToList();
                    }
                    if (!string.IsNullOrEmpty(Filter.ResidentPhoneno?.ToString()))
                    {
                        ResidentList = ResidentList.Where(x => x.Phoneno == Filter.ResidentPhoneno).ToList();
                    }
                }
                Obj.List = ResidentList;
                Obj.DropdownProperty = _propertyService.GetPropertyDropdown();
                Obj.DropdownBlock = _blockService.GetBlockDropdown();
                Obj.DropdownUnit = _unitService.GetUnitDropdown();
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
                ResidentViewModel Obj = new ResidentViewModel();
                Obj.DropdownProperty = _propertyService.GetPropertyDropdown();
                Obj.DropdownBlock = _blockService.GetBlockDropdown();
                Obj.DropdownUnit = _unitService.GetUnitDropdown();
                return View(Obj);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Submit(Resident RequestObj)
        {
            if (Session["UserId"] != null)
            {
                if (RequestObj.Id == 0)
                {
                    _residentService.CreateResident(RequestObj);
                }
                else
                {
                    _residentService.UpdateResident(RequestObj);
                }
                return RedirectToAction("List", "Resident");
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
                var request = _residentService.GetResident(Id);
                ResidentViewModel Obj = new ResidentViewModel()
                {
                    Id = request.Id,
                    Username = request.Username,
                    Password = request.Password,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Email = request.Email,
                    Phoneno = request.Phoneno,
                    Detailedinfo = request.Detailedinfo,
                    PropertyId = request.PropertyId,
                    BlockId = request.BlockId,
                    UnitId = request.UnitId,
                    Modifiedby = request.Modifiedby,
                    Modifieddate = request.Modifieddate,
                };
                Obj.DropdownProperty = _propertyService.GetPropertyDropdown();
                Obj.DropdownBlock = _blockService.GetBlockDropdown();
                Obj.DropdownUnit = _unitService.GetUnitDropdown();
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
                _residentService.DeleteResident(Id);
                return RedirectToAction("List", "Resident");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public JsonResult GetResidentByBlockAndUnit(int blockId, int unitId)
        {
            var resident = _residentService.GetResidents()
                .Where(r => r.BlockId == blockId && r.UnitId == unitId)
                .Select(r => new { r.Firstname, r.Lastname })
                .FirstOrDefault();

            return Json(resident, JsonRequestBehavior.AllowGet);
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
