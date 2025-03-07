
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
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.Propertys;


namespace WebAPI.Controllers
{
     public class PropertyController : ApiController
    {
        public readonly ICityService _cityService = new CityService();
public readonly IStateService _stateService = new StateService();
public readonly ICountryService _countryService = new CountryService();
public readonly IPropertyService _propertyService = new PropertyService();


        [System.Web.Http.Route("Property/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyList = _propertyService.GetPropertys();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("Property/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyService.GetProperty(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("Property/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(Property RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyService.CreateProperty(RequestObj);
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

        [System.Web.Http.Route("Property/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(Property RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyService.UpdateProperty(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("Property/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var Property = _propertyService.GetProperty(id);
               // Property.IsDeleted = 1;
                _propertyService.UpdateProperty(Property);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


