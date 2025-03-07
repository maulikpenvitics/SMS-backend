
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
 using Data.PropertyAssetss;


namespace WebAPI.Controllers
{
     public class PropertyAssetsController : ApiController
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyAssetsService _propertyassetsService = new PropertyAssetsService();


        [System.Web.Http.Route("PropertyAssets/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyAssetsList = _propertyassetsService.GetPropertyAssetss();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyAssetsList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyAssets/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyassetsService.GetPropertyAssets(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyAssets/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyAssets RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyassetsService.CreatePropertyAssets(RequestObj);
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

        [System.Web.Http.Route("PropertyAssets/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyAssets RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyassetsService.UpdatePropertyAssets(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyAssets/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyAssets = _propertyassetsService.GetPropertyAssets(id);
               // PropertyAssets.IsDeleted = 1;
                _propertyassetsService.UpdatePropertyAssets(PropertyAssets);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


