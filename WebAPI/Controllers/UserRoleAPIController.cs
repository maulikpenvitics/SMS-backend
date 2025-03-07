
using Domain.Entities;
using System.Web.Mvc;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;
 using Data.Users;
 using Data.Roles;
 using Data.UserRoles;


namespace WebAPI.Controllers
{
     public class UserRoleController : ApiController
    {
          public readonly IUserService _userService = new UserService();
public readonly IRoleService _roleService = new RoleService();
public readonly IUserRoleService _userroleService = new UserRoleService();


        [System.Web.Http.Route("UserRole/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var UserRoleList = _userroleService.GetUserRoles();
                return Request.CreateResponse(HttpStatusCode.OK, UserRoleList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("UserRole/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _userroleService.GetUserRole(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("UserRole/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(UserRole RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _userroleService.CreateUserRole(RequestObj);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("UserRole/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(UserRole RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _userroleService.UpdateUserRole(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("UserRole/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var UserRole = _userroleService.GetUserRole(id);
               // UserRole.IsDeleted = 1;
                _userroleService.UpdateUserRole(UserRole);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


