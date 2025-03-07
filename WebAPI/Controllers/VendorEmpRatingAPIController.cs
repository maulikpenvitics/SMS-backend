
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
 using Data.VendorEmployees;
 using Data.VendorEmpRatings;


namespace WebAPI.Controllers
{
     public class VendorEmpRatingController : ApiController
    {
        public readonly IVendorEmployeeService _vendoremployeeService = new VendorEmployeeService();
public readonly IVendorEmpRatingService _vendorempratingService = new VendorEmpRatingService();


        [System.Web.Http.Route("VendorEmpRating/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var VendorEmpRatingList = _vendorempratingService.GetVendorEmpRatings();
                return Request.CreateResponse(HttpStatusCode.OK, VendorEmpRatingList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("VendorEmpRating/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _vendorempratingService.GetVendorEmpRating(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("VendorEmpRating/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(VendorEmpRating RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _vendorempratingService.CreateVendorEmpRating(RequestObj);
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

        [System.Web.Http.Route("VendorEmpRating/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(VendorEmpRating RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _vendorempratingService.UpdateVendorEmpRating(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("VendorEmpRating/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var VendorEmpRating = _vendorempratingService.GetVendorEmpRating(id);
               // VendorEmpRating.IsDeleted = 1;
                _vendorempratingService.UpdateVendorEmpRating(VendorEmpRating);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


