 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Propertys;
using Data.Users;
using Data.PropertyDocss;


namespace Data.PropertyDocss
{
     public interface IPropertyDocsService
    {
        List<PropertyDocsResponseModel> GetPropertyDocss();
        PropertyDocs GetPropertyDocs(int Id);
        void CreatePropertyDocs(PropertyDocs PropertyDocsObj);
        void UpdatePropertyDocs(PropertyDocs PropertyDocsObj);
        bool DeletePropertyDocs(int Id);
       
         
    }
    public class PropertyDocsService : IPropertyDocsService
    {
        
  private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());

 private readonly IPropertyDocsRepository _propertydocsRepository = new PropertyDocsRepository(new DbFactory());
        private readonly IUserRepository _userRepository = new UserRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<PropertyDocsResponseModel> GetPropertyDocss()
        {
                var PropertyDocsList = (
                                           from _propertydocs in _propertydocsRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _propertydocs.PropertyId equals _property.Id
 join  _user in _userRepository.GetAll() on  _propertydocs.UserId equals _user.Id
 

                                          select new PropertyDocsResponseModel
                                          {
                                               Id = _propertydocs.Id,
PropertyId = _property.Id,
PropertyName = _property.Propertyname,
UserId = _user.Id,
Username = _user.Username,
Docurl = _propertydocs.Docurl,
Modifiedby = _propertydocs.Modifiedby,
Modifieddate = _propertydocs.Modifieddate,


                                          }).ToList();
                    return PropertyDocsList;
            

        }
        public PropertyDocs GetPropertyDocs(int Id)
        {
            var Result = _propertydocsRepository.GetById(Id);
            return Result;
        }
        public void CreatePropertyDocs(PropertyDocs PropertyDocsObj)
        {
            _propertydocsRepository.Add(PropertyDocsObj);
        }
        public void UpdatePropertyDocs(PropertyDocs PropertyDocsObj)
        {
            _propertydocsRepository.Update(PropertyDocsObj);
        }

        public bool DeletePropertyDocs(int Id)
        {
            var Result = _propertydocsRepository.GetById(Id);
            _propertydocsRepository.Delete(Result);
            return true;
        }
       
         
    }
}
   


