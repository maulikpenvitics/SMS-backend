using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Data.Blocks;
using Data.Units;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class UnitController : Controller
    {
        public readonly IBlockService _blockService = new BlockService();
        public readonly IUnitService _unitService = new UnitService();

        public ActionResult List(UnitFilter Filter)
        {
            if (Session["UserId"] != null)
            {
                UnitListViewModel Obj = new UnitListViewModel();
                var UnitList = _unitService.GetUnits();

                if (Filter.FilterSwitch)
                {
                    if (!string.IsNullOrEmpty(Filter.Unitname))
                    {
                        UnitList = UnitList.Where(x => x.Unitname.ToLower().Contains(Filter.Unitname.ToLower())).ToList();
                    }
                }

                Obj.List = UnitList;
                Obj.DropdownBlock = _blockService.GetBlockDropdown();

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
                UnitViewModel Obj = new UnitViewModel();
                Obj.DropdownBlock = _blockService.GetBlockDropdown();

                return View(Obj);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Submit(Domain.Entities.Unit RequestObj)
        {
            if (Session["UserId"] != null)
            {
                if (RequestObj.Id == 0)
                {
                    _unitService.CreateUnit(RequestObj);
                }
                else
                {
                    _unitService.UpdateUnit(RequestObj);
                }
                return RedirectToAction("List", "Unit");
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
                var request = _unitService.GetUnit(Id);
                UnitViewModel Obj = new UnitViewModel()
                {
                    Id = request.Id,
                    Unitname = request.Unitname,
                    BlockId = request.BlockId
                };
                Obj.DropdownBlock = _blockService.GetBlockDropdown();

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
                _unitService.DeleteUnit(Id);
                return RedirectToAction("List", "Unit");
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
