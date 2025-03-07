
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

 using Data.PropertyDocss;
using System.Web.UI;
using Data.Users;


namespace WebAPI.Controllers
{
     public class PropertyDocsController : ApiController
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IPropertyDocsService _propertydocsService = new PropertyDocsService();
        public readonly IUserService _userService = new UserService();


        [System.Web.Http.Route("PropertyDocs/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyDocsList = _propertydocsService.GetPropertyDocss();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyDocsList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyDocs/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertydocsService.GetPropertyDocs(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyDocs/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyDocs RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertydocsService.CreatePropertyDocs(RequestObj);
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

        [System.Web.Http.Route("PropertyDocs/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyDocs RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertydocsService.UpdatePropertyDocs(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyDocs/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyDocs = _propertydocsService.GetPropertyDocs(id);
                //PropertyDocs.IsDeleted = 1;
                _propertydocsService.UpdatePropertyDocs(PropertyDocs);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


