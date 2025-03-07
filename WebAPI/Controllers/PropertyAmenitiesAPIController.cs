
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
 using Data.PropertyAmenitiess;


namespace WebAPI.Controllers
{
     public class PropertyAmenitiesController : ApiController
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyAmenitiesService _propertyamenitiesService = new PropertyAmenitiesService();


        [System.Web.Http.Route("PropertyAmenities/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyAmenitiesList = _propertyamenitiesService.GetPropertyAmenitiess();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyAmenitiesList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyAmenities/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyamenitiesService.GetPropertyAmenities(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyAmenities/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyAmenities RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyamenitiesService.CreatePropertyAmenities(RequestObj);
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

        [System.Web.Http.Route("PropertyAmenities/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyAmenities RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyamenitiesService.UpdatePropertyAmenities(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyAmenities/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyAmenities = _propertyamenitiesService.GetPropertyAmenities(id);
                //PropertyAmenities.IsDeleted = 1;
                _propertyamenitiesService.UpdatePropertyAmenities(PropertyAmenities);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


