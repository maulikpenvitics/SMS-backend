
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
 using Data.VendorEmployeeDocs;


namespace WebAPI.Controllers
{
     public class VendorEmployeeDocController : ApiController
    {
        public readonly IVendorEmployeeDocService _vendoremployeedocService = new VendorEmployeeDocService();


        [System.Web.Http.Route("VendorEmployeeDoc/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var VendorEmployeeDocList = _vendoremployeedocService.GetVendorEmployeeDocs();
                return Request.CreateResponse(HttpStatusCode.OK, VendorEmployeeDocList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("VendorEmployeeDoc/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _vendoremployeedocService.GetVendorEmployeeDoc(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("VendorEmployeeDoc/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(VendorEmployeeDoc RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _vendoremployeedocService.CreateVendorEmployeeDoc(RequestObj);
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

        [System.Web.Http.Route("VendorEmployeeDoc/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(VendorEmployeeDoc RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _vendoremployeedocService.UpdateVendorEmployeeDoc(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("VendorEmployeeDoc/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var VendorEmployeeDoc = _vendoremployeedocService.GetVendorEmployeeDoc(id);
               // VendorEmployeeDoc.IsDeleted = 1;
                _vendoremployeedocService.UpdateVendorEmployeeDoc(VendorEmployeeDoc);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


