 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.PropertyOwnerss;


namespace Data.PropertyOwnerss
{
     public interface IPropertyOwnersService
    {
        List<PropertyOwnersResponseModel> GetPropertyOwnerss();
        PropertyOwners GetPropertyOwners(int Id);
        void CreatePropertyOwners(PropertyOwners PropertyOwnersObj);
        void UpdatePropertyOwners(PropertyOwners PropertyOwnersObj);
        bool DeletePropertyOwners(int Id);
        List<SelectListItem> GetPropertyOwnersDropdown();
         
    }
    public class PropertyOwnersService : IPropertyOwnersService
    {
        
         private readonly IPropertyOwnersRepository _propertyownersRepository = new PropertyOwnersRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyOwnersResponseModel> GetPropertyOwnerss()
        {
                var PropertyOwnersList = (
                                           from _propertyowners in _propertyownersRepository.GetAll()

                                          select new PropertyOwnersResponseModel
                                          {
                                               Id = _propertyowners.Id,
Firstname = _propertyowners.Firstname,
Lastname = _propertyowners.Lastname,
Email = _propertyowners.Email,
Phoneno = _propertyowners.Phoneno,
BlockId = _propertyowners.BlockId,
Modifiedby = _propertyowners.Modifiedby,
Modifieddate = _propertyowners.Modifieddate,


                                          }).ToList();
                    return PropertyOwnersList;
            

        }
        public PropertyOwners GetPropertyOwners(int Id)
        {
            var Result = _propertyownersRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyOwners(PropertyOwners PropertyOwnersObj)
        {
            _propertyownersRepository.Add(PropertyOwnersObj);
        }
        public void UpdatePropertyOwners(PropertyOwners PropertyOwnersObj)
        {
            _propertyownersRepository.Update(PropertyOwnersObj);
        }

        public bool DeletePropertyOwners(int Id)
        {
            var Result = _propertyownersRepository.GetById(Id);
            _propertyownersRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetPropertyOwnersDropdown()
        {
            var Result = _propertyownersRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Firstname + " " + x.Lastname 

            }).ToList();
            return Result;
        }
         
    }
}
   


