
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
 using Data.PropertyOwnerss;


namespace WebAPI.Controllers
{
     public class PropertyOwnersController : ApiController
    {
        public readonly IPropertyOwnersService _propertyownersService = new PropertyOwnersService();


        [System.Web.Http.Route("PropertyOwners/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyOwnersList = _propertyownersService.GetPropertyOwnerss();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyOwnersList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyOwners/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyownersService.GetPropertyOwners(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyOwners/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyOwners RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyownersService.CreatePropertyOwners(RequestObj);
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

        [System.Web.Http.Route("PropertyOwners/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyOwners RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyownersService.UpdatePropertyOwners(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyOwners/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyOwners = _propertyownersService.GetPropertyOwners(id);
                ///PropertyOwners.IsDeleted = 1;
                _propertyownersService.UpdatePropertyOwners(PropertyOwners);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


