
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
 using Data.PropertyVehicles;


namespace WebAPI.Controllers
{
     public class PropertyVehicleController : ApiController
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyVehicleService _propertyvehicleService = new PropertyVehicleService();


        [System.Web.Http.Route("PropertyVehicle/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyVehicleList = _propertyvehicleService.GetPropertyVehicles();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyVehicleList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyVehicle/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyvehicleService.GetPropertyVehicle(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyVehicle/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyVehicle RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyvehicleService.CreatePropertyVehicle(RequestObj);
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

        [System.Web.Http.Route("PropertyVehicle/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyVehicle RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyvehicleService.UpdatePropertyVehicle(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyVehicle/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyVehicle = _propertyvehicleService.GetPropertyVehicle(id);
               // PropertyVehicle.IsDeleted = 1;
                _propertyvehicleService.UpdatePropertyVehicle(PropertyVehicle);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


