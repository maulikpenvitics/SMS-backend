
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
 using Data.VendorEmployeeRoles;


namespace WebAPI.Controllers
{
     public class VendorEmployeeRoleController : ApiController
    {
        public readonly IVendorEmployeeRoleService _vendoremployeeroleService = new VendorEmployeeRoleService();


        [System.Web.Http.Route("VendorEmployeeRole/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var VendorEmployeeRoleList = _vendoremployeeroleService.GetVendorEmployeeRoles();
                return Request.CreateResponse(HttpStatusCode.OK, VendorEmployeeRoleList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("VendorEmployeeRole/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _vendoremployeeroleService.GetVendorEmployeeRole(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("VendorEmployeeRole/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(VendorEmployeeRole RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _vendoremployeeroleService.CreateVendorEmployeeRole(RequestObj);
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

        [System.Web.Http.Route("VendorEmployeeRole/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(VendorEmployeeRole RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _vendoremployeeroleService.UpdateVendorEmployeeRole(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("VendorEmployeeRole/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var VendorEmployeeRole = _vendoremployeeroleService.GetVendorEmployeeRole(id);
               // VendorEmployeeRole.IsDeleted = 1;
                _vendoremployeeroleService.UpdateVendorEmployeeRole(VendorEmployeeRole);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


