
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
 using Data.Propertys;
 using Data.Roles;
 using Data.Users;


namespace WebAPI.Controllers
{
     public class UserController : ApiController
    {
           public readonly IPropertyService _propertyService = new PropertyService();
public readonly IRoleService _roleService = new RoleService();
public readonly IUserService _userService = new UserService();


        [System.Web.Http.Route("User/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var UserList = _userService.GetUsers();
                return Request.CreateResponse(HttpStatusCode.OK, UserList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
            
        [System.Web.Http.Route("User/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _userService.GetUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("User/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(User RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _userService.CreateUser(RequestObj);
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

        [System.Web.Http.Route("User/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(User RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _userService.UpdateUser(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("User/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var User = _userService.GetUser(id);
              //  User.IsDeleted = 1;
                _userService.UpdateUser(User);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


