 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Users;
 using Data.Roles;
 using Data.UserRoles;


namespace Data.UserRoles
{
     public interface IUserRoleService
    {
        List<UserRoleResponseModel> GetUserRoles();
        UserRole GetUserRole(int Id);
        void CreateUserRole(UserRole UserRoleObj);
        void UpdateUserRole(UserRole UserRoleObj);
        bool DeleteUserRole(int Id);
       
         
    }
    public class UserRoleService : IUserRoleService
    {
        
         private readonly IUserRepository _userRepository = new UserRepository(new DbFactory());
 private readonly IRoleRepository _roleRepository = new RoleRepository(new DbFactory());
 private readonly IUserRoleRepository _userroleRepository = new UserRoleRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<UserRoleResponseModel> GetUserRoles()
        {
                var UserRoleList = (
                                           from _userrole in _userroleRepository.GetAll()
 join  _user in _userRepository.GetAll() on  _userrole.UserId equals _user.Id
 join  _role in _roleRepository.GetAll() on  _userrole.RoleId equals _role.Id

                                          select new UserRoleResponseModel
                                          {
                                               Id = _userrole.Id,
UserId = _user.Id,
userName = _user.Firstname+" "+_user.Lastname,
RoleId = _role.Id,
roleName = _role.Name,
Modifiedby = _userrole.Modifiedby,
Modifieddate = _userrole.Modifieddate,


                                          }).ToList();
                    return UserRoleList;
            

        }
        public UserRole GetUserRole(int Id)
        {
            var Result = _userroleRepository.GetById(Id);
            return Result;
        }
        public void CreateUserRole(UserRole UserRoleObj)
        {
            _userroleRepository.Add(UserRoleObj);
        }
        public void UpdateUserRole(UserRole UserRoleObj)
        {
            _userroleRepository.Update(UserRoleObj);
        }

        public bool DeleteUserRole(int Id)
        {
            var Result = _userroleRepository.GetById(Id);
            _userroleRepository.Delete(Result);
            return true;
        }
      
         
    }
}
   


