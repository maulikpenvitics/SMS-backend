 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyAssetss;


namespace Data.PropertyAssetss
{
     public interface IPropertyAssetsService
    {
        List<PropertyAssetsResponseModel> GetPropertyAssetss();
        PropertyAssets GetPropertyAssets(int Id);
        void CreatePropertyAssets(PropertyAssets PropertyAssetsObj);
        void UpdatePropertyAssets(PropertyAssets PropertyAssetsObj);
        bool DeletePropertyAssets(int Id);
      
         
    }
    public class PropertyAssetsService : IPropertyAssetsService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IPropertyAssetsRepository _propertyassetsRepository = new PropertyAssetsRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyAssetsResponseModel> GetPropertyAssetss()
        {
                var PropertyAssetsList = (
                                           from _propertyassets in _propertyassetsRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _propertyassets.PropertyId equals _property.Id

                                          select new PropertyAssetsResponseModel
                                          {
                                               Id = _propertyassets.Id,
PropertyId = _property.Id,
PropertyName = _property.Propertyname,
Assetname = _propertyassets.Assetname,
Assetnumber = _propertyassets.Assetnumber,
Modifiedby = _propertyassets.Modifiedby,
Modifieddate = _propertyassets.Modifieddate,


                                          }).ToList();
                    return PropertyAssetsList;
            

        }
        public PropertyAssets GetPropertyAssets(int Id)
        {
            var Result = _propertyassetsRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyAssets(PropertyAssets PropertyAssetsObj)
        {
            _propertyassetsRepository.Add(PropertyAssetsObj);
        }
        public void UpdatePropertyAssets(PropertyAssets PropertyAssetsObj)
        {
            _propertyassetsRepository.Update(PropertyAssetsObj);
        }

        public bool DeletePropertyAssets(int Id)
        {
            var Result = _propertyassetsRepository.GetById(Id);
            _propertyassetsRepository.Delete(Result);
            return true;
        }
       
         
    }
}
   


