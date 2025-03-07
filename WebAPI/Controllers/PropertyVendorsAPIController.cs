
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
 using Data.PropertyVendorss;


namespace WebAPI.Controllers
{
     public class PropertyVendorsController : ApiController
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyVendorsService _propertyvendorsService = new PropertyVendorsService();


        [System.Web.Http.Route("PropertyVendors/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyVendorsList = _propertyvendorsService.GetPropertyVendorss();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyVendorsList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyVendors/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyvendorsService.GetPropertyVendors(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyVendors/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyVendors RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyvendorsService.CreatePropertyVendors(RequestObj);
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

        [System.Web.Http.Route("PropertyVendors/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyVendors RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyvendorsService.UpdatePropertyVendors(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyVendors/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyVendors = _propertyvendorsService.GetPropertyVendors(id);
               // PropertyVendors.IsDeleted = 1;
                _propertyvendorsService.UpdatePropertyVendors(PropertyVendors);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


