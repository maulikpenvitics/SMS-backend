 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyAmenitiess;


namespace Data.PropertyAmenitiess
{
     public interface IPropertyAmenitiesService
    {
        List<PropertyAmenitiesResponseModel> GetPropertyAmenitiess();
        PropertyAmenities GetPropertyAmenities(int Id);
        void CreatePropertyAmenities(PropertyAmenities PropertyAmenitiesObj);
        void UpdatePropertyAmenities(PropertyAmenities PropertyAmenitiesObj);
        bool DeletePropertyAmenities(int Id);
       
         
    }
    public class PropertyAmenitiesService : IPropertyAmenitiesService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IPropertyAmenitiesRepository _propertyamenitiesRepository = new PropertyAmenitiesRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyAmenitiesResponseModel> GetPropertyAmenitiess()
        {
                var PropertyAmenitiesList = (
                                           from _propertyamenities in _propertyamenitiesRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _propertyamenities.PropertyId equals _property.Id

                                          select new PropertyAmenitiesResponseModel
                                          {
                                               Id = _propertyamenities.Id,
PropertyId = _property.Id,
PropertyName = _property.Propertyname,
Amenityname = _propertyamenities.Amenityname,
Modifiedby = _propertyamenities.Modifiedby,
ModifiedDate = _propertyamenities.ModifiedDate,


                                          }).ToList();
                    return PropertyAmenitiesList;
            

        }
        public PropertyAmenities GetPropertyAmenities(int Id)
        {
            var Result = _propertyamenitiesRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyAmenities(PropertyAmenities PropertyAmenitiesObj)
        {
            _propertyamenitiesRepository.Add(PropertyAmenitiesObj);
        }
        public void UpdatePropertyAmenities(PropertyAmenities PropertyAmenitiesObj)
        {
            _propertyamenitiesRepository.Update(PropertyAmenitiesObj);
        }

        public bool DeletePropertyAmenities(int Id)
        {
            var Result = _propertyamenitiesRepository.GetById(Id);
            _propertyamenitiesRepository.Delete(Result);
            return true;
        }
      
    }
}
   


