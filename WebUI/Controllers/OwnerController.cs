using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebSockets;
using Data;
using Data.Residents;
using WebUI.Models;


namespace WebUI.Controllers
{
    public class OwnerController : Controller
    {
        private readonly RMSEntities dataContext=new RMSEntities();  
        private static List<OwnerViewModel> _owners = new List<OwnerViewModel>();
        public readonly IResidentService _residentService = new ResidentService();

        public async Task< ActionResult > List()
        {
            var data = await dataContext.Blocks
                .Include(b => b.Residents)  // Include Residents inside Blocks
                .Include("Residents.Unit")   // Include the Unit for each Resident
                .ToListAsync();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(OwnerViewModel owner)
        {
            if (owner.Id == 0)
            {
                owner.Id = _owners.Count + 1;
                _owners.Add(owner);
            }
            else
            {
                var existingOwner = _owners.FirstOrDefault(o => o.Id == owner.Id);
                if (existingOwner != null)
                {
                    existingOwner.Blockname = owner.Blockname;
                    existingOwner.Unitname = owner.Unitname;
                    existingOwner.Residentname = owner.Residentname;
                }
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var owner = _owners.FirstOrDefault(o => o.Id == id);
            if (owner == null)
                return HttpNotFound();
            return View(owner);
        }

        public ActionResult Delete(int id)
        {
            var owner = _owners.FirstOrDefault(o => o.Id == id);
            if (owner != null)
            {
                _owners.Remove(owner);
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult JsTreeDemo()
        {
            return View();
        }
        public JsonResult Nodes()
        {
            var nodes = new List<JsTreeModel>();
            nodes.Add(new JsTreeModel() { id = "101", parent = "#", text = "Kunal" });
            nodes.Add(new JsTreeModel() { id = "102", parent = "#", text = "Root node 1" });
            nodes.Add(new JsTreeModel() { id = "103", parent = "102", text = "Child 1" });
            nodes.Add(new JsTreeModel() { id = "104", parent = "102", text = "Child 2" });
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetResidentsTree()
        //  {
        //      var residents = _residentService.GetAllResidents(); // Fetch residents from service or DB.

        //      var treeData = residents.Select(resident => new
        //      {
        //          id = resident.Id.ToString(),
        //          parent = resident.BlockId?.ToString() ?? "#", // Set parent dynamically
        //          text = $"{resident.Firstname} {resident.Lastname}"
        //      }).ToList();

        //      return Json(treeData, JsonRequestBehavior.AllowGet);
        //  }

        //[HttpGet]
        //    public JsonResult GetResidentByBlockAndUnit(string blockName, string unitName)
        //    {
        //        var owner = _owners.FirstOrDefault(o => o.Blockname == blockName && o.Unitname == unitName);
        //        return Json(owner != null ? new { owner.Residentname } : new { Residentname = "No Resident Found" }, JsonRequestBehavior.AllowGet);
        //    }

        //    public static string GetEnumDescription(Enum value)
        //    {
        //        FieldInfo fi = value.GetType().GetField(value.ToString());
        //        DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
        //        if (attributes != null && attributes.Any())
        //        {
        //            return attributes.First().Description;
        //        }
        //        return value.ToString();
        //    } 
    }
}
