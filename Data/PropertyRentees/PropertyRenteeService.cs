 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.PropertyRentees;


namespace Data.PropertyRentees
{
     public interface IPropertyRenteeService
    {
        List<PropertyRenteeResponseModel> GetPropertyRentees();
        PropertyRentee GetPropertyRentee(int Id);
        void CreatePropertyRentee(PropertyRentee PropertyRenteeObj);
        void UpdatePropertyRentee(PropertyRentee PropertyRenteeObj);
        bool DeletePropertyRentee(int Id);
        List<SelectListItem> GetPropertyRenteeDropdown();
         
    }
    public class PropertyRenteeService : IPropertyRenteeService
    {
        
         private readonly IPropertyRenteeRepository _propertyrenteeRepository = new PropertyRenteeRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyRenteeResponseModel> GetPropertyRentees()
        {
                var PropertyRenteeList = (
                                           from _propertyrentee in _propertyrenteeRepository.GetAll()

                                          select new PropertyRenteeResponseModel
                                          {
                                               Id = _propertyrentee.Id,
Firstname = _propertyrentee.Firstname,
Lastname = _propertyrentee.Lastname,
Email = _propertyrentee.Email,
Phoneno = _propertyrentee.Phoneno,
BlockId = _propertyrentee.BlockId,
Unitno = _propertyrentee.Unitno,
Profession = _propertyrentee.Profession,
Modifiedby = _propertyrentee.Modifiedby,
Modifieddate = _propertyrentee.Modifieddate,


                                          }).ToList();
                    return PropertyRenteeList;
            

        }
        public PropertyRentee GetPropertyRentee(int Id)
        {
            var Result = _propertyrenteeRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyRentee(PropertyRentee PropertyRenteeObj)
        {
            _propertyrenteeRepository.Add(PropertyRenteeObj);
        }
        public void UpdatePropertyRentee(PropertyRentee PropertyRenteeObj)
        {
            _propertyrenteeRepository.Update(PropertyRenteeObj);
        }

        public bool DeletePropertyRentee(int Id)
        {
            var Result = _propertyrenteeRepository.GetById(Id);
            _propertyrenteeRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetPropertyRenteeDropdown()
        {
            var Result = _propertyrenteeRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Firstname + " " + x.Lastname

            }).ToList();
            return Result;
        }
         
    }
}
   


