
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
 using Data.PropertyAdvertisements;


namespace WebAPI.Controllers
{
     public class PropertyAdvertisementController : ApiController
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyAdvertisementService _propertyadvertisementService = new PropertyAdvertisementService();


        [System.Web.Http.Route("PropertyAdvertisement/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyAdvertisementList = _propertyadvertisementService.GetPropertyAdvertisements();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyAdvertisementList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyAdvertisement/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyadvertisementService.GetPropertyAdvertisement(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyAdvertisement/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyAdvertisement RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyadvertisementService.CreatePropertyAdvertisement(RequestObj);
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

        [System.Web.Http.Route("PropertyAdvertisement/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyAdvertisement RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyadvertisementService.UpdatePropertyAdvertisement(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyAdvertisement/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyAdvertisement = _propertyadvertisementService.GetPropertyAdvertisement(id);
               // PropertyAdvertisement.IsDeleted = 1;
                _propertyadvertisementService.UpdatePropertyAdvertisement(PropertyAdvertisement);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


