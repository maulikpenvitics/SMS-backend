using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
 using Data.Categorys;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
     public class CategoryController : Controller
    {
	
        public readonly ICategoryService _categoryService = new CategoryService();
         
       public ActionResult List(CategoryFilter Filter)
       {
           if (Session["UserId"] != null)
           {
		        CategoryListViewModel Obj = new CategoryListViewModel();
                     var CategoryList = _categoryService.GetCategorys();
                 if (Filter.FilterSwitch){
                      
                 }
                Obj.List = CategoryList;
                
                
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
			    CategoryViewModel Obj = new CategoryViewModel();
                
                
                return View(Obj);
			}
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        public ActionResult Submit(Category RequestObj)
        {
            if (Session["UserId"] != null)
            {
			     if (RequestObj.Id == 0)
                 {
                    _categoryService.CreateCategory(RequestObj);
                 }
                 else
                 {
                     _categoryService.UpdateCategory(RequestObj);
                 }
                 return RedirectToAction("List", "Category");
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
			     var request = _categoryService.GetCategory(Id);
                CategoryViewModel Obj = new CategoryViewModel()
                {
                    Id= request.Id,
Name= request.Name,
CreatedBy= request.CreatedBy,
ModifiedBy= request.ModifiedBy,
CreatedDate= request.CreatedDate,
ModifiedDate= request.ModifiedDate,
IsActive= request.IsActive,
IsDeleted= request.IsDeleted,

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
			  _categoryService.DeleteCategory(Id);
                return RedirectToAction("List", "Category");
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
   


