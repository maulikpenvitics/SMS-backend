
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
 using Data.Residents;
 using Data.Users;
 using Data.Vendors;
 using Data.Securitys;


namespace WebAPI.Controllers
{
     public class SecurityController : ApiController
    {
        public readonly IResidentService _residentService = new ResidentService();
public readonly IUserService _userService = new UserService();
public readonly IVendorService _vendorService = new Data.Vendors.VendorService();
public readonly ISecurityService _securityService = new SecurityService();


        [System.Web.Http.Route("Security/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var SecurityList = _securityService.GetSecuritys();
                return Request.CreateResponse(HttpStatusCode.OK, SecurityList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("Security/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _securityService.GetSecurity(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("Security/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(Security RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _securityService.CreateSecurity(RequestObj);
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

        [System.Web.Http.Route("Security/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(Security RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _securityService.UpdateSecurity(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("Security/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var Security = _securityService.GetSecurity(id);
               // Security.IsDeleted = 1;
                _securityService.UpdateSecurity(Security);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


