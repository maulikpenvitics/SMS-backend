
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


namespace WebUI.Controllers
{
     public class BlockController : Controller
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IBlockService _blockService = new BlockService();


       public ActionResult List(BlockFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        BlockListViewModel Obj = new BlockListViewModel();
                     var BlockList = _blockService.GetBlocks();
                 if (Filter.FilterSwitch){
                      if(!string.IsNullOrEmpty(Filter.BlockBlockname))
{
 BlockList = BlockList.Where(x => x.Blockname.ToLower().Contains(Filter.BlockBlockname.ToLower())).ToList();
}
                 }
                Obj.List = BlockList;
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
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
			    BlockViewModel Obj = new BlockViewModel();
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Block RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _blockService.CreateBlock(RequestObj);
                 }
                 else
                 {
                     _blockService.UpdateBlock(RequestObj);
                 }
                 return RedirectToAction("List", "Block");
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
			     var request = _blockService.GetBlock(Id);
                BlockViewModel Obj = new BlockViewModel()
                {
                    Id= request.Id,
Blockname= request.Blockname,
PropertyId= request.PropertyId,
Modifiedby= request.Modifiedby,
Modifieddate= request.Modifieddate,

                };
                 Obj.DropdownProperty = _propertyService.GetPropertyDropdown();

                
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
			  _blockService.DeleteBlock(Id);
                return RedirectToAction("List", "Block");
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
   


