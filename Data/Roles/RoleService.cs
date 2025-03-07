 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Roles;


namespace Data.Roles
{
     public interface IRoleService
    {
        List<RoleResponseModel> GetRoles();
        Role GetRole(int Id);
        void CreateRole(Role RoleObj);
        void UpdateRole(Role RoleObj);
        bool DeleteRole(int Id);
        List<SelectListItem> GetRoleDropdown();
         
    }
    public class RoleService : IRoleService
    {
        
         private readonly IRoleRepository _roleRepository = new RoleRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<RoleResponseModel> GetRoles()
        {
                var RoleList = (
                                           from _role in _roleRepository.GetAll()

                                          select new RoleResponseModel
                                          {
                                               Id = _role.Id,
Name = _role.Name,
ModifiedBy = _role.ModifiedBy,
ModifiedDate = _role.ModifiedDate,


                                          }).ToList();
                    return RoleList;
            

        }
        public Role GetRole(int Id)
        {
            var Result = _roleRepository.GetById(Id);
            return Result;
        }
        public void CreateRole(Role RoleObj)
        {
            _roleRepository.Add(RoleObj);
        }
        public void UpdateRole(Role RoleObj)
        {
            _roleRepository.Update(RoleObj);
        }

        public bool DeleteRole(int Id)
        {
            var Result = _roleRepository.GetById(Id);
            _roleRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetRoleDropdown()
        {
            var Result = _roleRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Name.ToString() 

            }).ToList();
            return Result;
        }
         
    }
}
   


