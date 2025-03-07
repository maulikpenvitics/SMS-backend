
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
 using Data.PropertyVehicles;
 using Data.PropertyVehicleTitos;


namespace WebAPI.Controllers
{
     public class PropertyVehicleTitoController : ApiController
    {
        public readonly IPropertyVehicleService _propertyvehicleService = new PropertyVehicleService();
public readonly IPropertyVehicleTitoService _propertyvehicletitoService = new PropertyVehicleTitoService();


        [System.Web.Http.Route("PropertyVehicleTito/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyVehicleTitoList = _propertyvehicletitoService.GetPropertyVehicleTitos();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyVehicleTitoList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyVehicleTito/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyvehicletitoService.GetPropertyVehicleTito(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyVehicleTito/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyVehicleTito RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyvehicletitoService.CreatePropertyVehicleTito(RequestObj);
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

        [System.Web.Http.Route("PropertyVehicleTito/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyVehicleTito RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyvehicletitoService.UpdatePropertyVehicleTito(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyVehicleTito/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyVehicleTito = _propertyvehicletitoService.GetPropertyVehicleTito(id);
               // PropertyVehicleTito.IsDeleted = 1;
                _propertyvehicletitoService.UpdatePropertyVehicleTito(PropertyVehicleTito);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


