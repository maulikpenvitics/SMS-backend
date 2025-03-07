
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
 using Data.VendorInvoiceDetails;


namespace WebAPI.Controllers
{
     public class VendorInvoiceDetailController : ApiController
    {
        public readonly IVendorInvoiceDetailService _vendorinvoicedetailService = new VendorInvoiceDetailService();


        [System.Web.Http.Route("VendorInvoiceDetail/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var VendorInvoiceDetailList = _vendorinvoicedetailService.GetVendorInvoiceDetails();
                return Request.CreateResponse(HttpStatusCode.OK, VendorInvoiceDetailList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("VendorInvoiceDetail/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _vendorinvoicedetailService.GetVendorInvoiceDetail(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("VendorInvoiceDetail/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(VendorInvoiceDetail RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _vendorinvoicedetailService.CreateVendorInvoiceDetail(RequestObj);
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

        [System.Web.Http.Route("VendorInvoiceDetail/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(VendorInvoiceDetail RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _vendorinvoicedetailService.UpdateVendorInvoiceDetail(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("VendorInvoiceDetail/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var VendorInvoiceDetail = _vendorinvoicedetailService.GetVendorInvoiceDetail(id);
               // VendorInvoiceDetail.IsDeleted = 1;
                _vendorinvoicedetailService.UpdateVendorInvoiceDetail(VendorInvoiceDetail);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


