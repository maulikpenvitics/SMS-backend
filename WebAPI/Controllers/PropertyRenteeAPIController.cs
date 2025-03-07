
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
 using Data.PropertyRentees;


namespace WebAPI.Controllers
{
     public class PropertyRenteeController : ApiController
    {
        public readonly IPropertyRenteeService _propertyrenteeService = new PropertyRenteeService();


        [System.Web.Http.Route("PropertyRentee/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyRenteeList = _propertyrenteeService.GetPropertyRentees();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyRenteeList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyRentee/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyrenteeService.GetPropertyRentee(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyRentee/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyRentee RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyrenteeService.CreatePropertyRentee(RequestObj);
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

        [System.Web.Http.Route("PropertyRentee/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyRentee RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyrenteeService.UpdatePropertyRentee(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyRentee/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyRentee = _propertyrenteeService.GetPropertyRentee(id);
              //  PropertyRentee.IsDeleted = 1;
                _propertyrenteeService.UpdatePropertyRentee(PropertyRentee);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


