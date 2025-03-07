using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Categorys;
using System.Web.Mvc;
using Domain.Entities;

namespace Data.Categorys
{
    public interface ICategoryService
    {
        List<CategoryResponseModel> GetCategorys();
        Category GetCategory(int Id);
        void CreateCategory(Category CategoryObj);
        void UpdateCategory(Category CategoryObj);
        bool DeleteCategory(int Id);
        List<SelectListItem> GetCategoryDropdown();

    }
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository = new CategoryRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());

        public List<CategoryResponseModel> GetCategorys()
        {
            var CategoryList = (
                                       from _category in _categoryRepository.GetAll()

                                       select new CategoryResponseModel
                                       {
                                           Id = _category.Id,
                                           Name = _category.Name,
                                           CreatedBy = _category.CreatedBy,
                                           ModifiedBy = _category.ModifiedBy,
                                           CreatedDate = _category.CreatedDate,
                                           ModifiedDate = _category.ModifiedDate,
                                           IsActive = _category.IsActive,
                                           IsDeleted = _category.IsDeleted,


                                       }).ToList();
            return CategoryList;


        }
        public Category GetCategory(int Id)
        {
            var Result = _categoryRepository.GetById(Id);
            return Result;
        }
        public void CreateCategory(Category CategoryObj)
        {
            _categoryRepository.Add(CategoryObj);
        }
        public void UpdateCategory(Category CategoryObj)
        {
            _categoryRepository.Update(CategoryObj);
        }

        public bool DeleteCategory(int Id)
        {
            var Result = _categoryRepository.GetById(Id);
            _categoryRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetCategoryDropdown()
        {
            var Result = _categoryRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()

            }).ToList();
            return Result;
        }

    }
}



