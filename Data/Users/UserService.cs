 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.Roles;
 using Data.Users;


namespace Data.Users
{
     public interface IUserService
    {
        List<UserResponseModel> GetUsers();
        User GetUser(int Id);
        void CreateUser(User UserObj);
        void UpdateUser(User UserObj);
        bool DeleteUser(int Id);
        List<SelectListItem> GetUserDropdown();
      

        //User AuthUser(string email,string password);


    }
    public class UserService : IUserService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IRoleRepository _roleRepository = new RoleRepository(new DbFactory());
 private readonly IUserRepository _userRepository = new UserRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<UserResponseModel> GetUsers()
        
        {
                var UserList = (
                                           from _user in _userRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _user.PropertyId equals _property.Id
 join  _role in _roleRepository.GetAll() on  _user.RoleId equals _role.Id

                                          select new UserResponseModel
                                          {
                                               Id = _user.Id,
Username = _user.Username,
Password = _user.Password,
Firstname = _user.Firstname,
Lastname = _user.Lastname,
Email = _user.Email,
Phone = _user.Phone,
PropertyId = _property.Id,
propertyName = _property.Propertyname,
RoleId = _role.Id,
roleName = _role.Name,
Modifiedby = _user.Modifiedby,
Modifieddate = _user.Modifieddate,


                                          }).ToList();
                    return UserList;
            

        }
        public User GetUser(int Id)
        {
            var Result = _userRepository.GetById(Id);
            return Result;
        }
        public void CreateUser(User UserObj)
        {
            _userRepository.Add(UserObj);
        }
        public void UpdateUser(User UserObj)
        {
            _userRepository.Update(UserObj);
        }

        public bool DeleteUser(int Id)
        {
            var Result = _userRepository.GetById(Id);
            _userRepository.Delete(Result);
            
            unitOfWork.Commit();
            return true;
        }
        public List<SelectListItem> GetUserDropdown()
        {
            var Result = _userRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Firstname+" "+x.Lastname

            }).ToList();
            return Result;
        }

        //public User AuthUser(string email, string password)
        //{
        //    var Result = _userRepository.GetAll().ToList().FirstOrDefault(x=>x.Email== email && x.Password==Convert.ToInt32(password));
        //    throw new NotImplementedException();
        //}
    }
}
   


