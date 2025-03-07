
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
 using Data.PropertyRenteeAgreements;


namespace WebAPI.Controllers
{
     public class PropertyRenteeAgreementController : ApiController
    {
        public readonly IPropertyRenteeService _propertyrenteeService = new PropertyRenteeService();
public readonly IPropertyRenteeAgreementService _propertyrenteeagreementService = new PropertyRenteeAgreementService();


        [System.Web.Http.Route("PropertyRenteeAgreement/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var PropertyRenteeAgreementList = _propertyrenteeagreementService.GetPropertyRenteeAgreements();
                return Request.CreateResponse(HttpStatusCode.OK, PropertyRenteeAgreementList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("PropertyRenteeAgreement/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _propertyrenteeagreementService.GetPropertyRenteeAgreement(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("PropertyRenteeAgreement/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(PropertyRenteeAgreement RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _propertyrenteeagreementService.CreatePropertyRenteeAgreement(RequestObj);
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

        [System.Web.Http.Route("PropertyRenteeAgreement/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(PropertyRenteeAgreement RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _propertyrenteeagreementService.UpdatePropertyRenteeAgreement(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("PropertyRenteeAgreement/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var PropertyRenteeAgreement = _propertyrenteeagreementService.GetPropertyRenteeAgreement(id);
                //PropertyRenteeAgreement.IsDeleted = 1;
                _propertyrenteeagreementService.UpdatePropertyRenteeAgreement(PropertyRenteeAgreement);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


