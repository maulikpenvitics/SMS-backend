
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
using Data.Vendors;
using Data.VendorInvoices;


namespace WebAPI.Controllers
{
    public class VendorInvoiceController : ApiController
    {
        public readonly IVendorService _vendorService = new Data.Vendors.VendorService();
        public readonly IVendorInvoiceService _vendorinvoiceService = new VendorInvoiceService();


        [System.Web.Http.Route("VendorInvoice/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var VendorInvoiceList = _vendorinvoiceService.GetVendorInvoices();
                return Request.CreateResponse(HttpStatusCode.OK, VendorInvoiceList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("VendorInvoice/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _vendorinvoiceService.GetVendorInvoice(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }

        }

        [System.Web.Http.Route("VendorInvoice/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(VendorInvoice RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _vendorinvoiceService.CreateVendorInvoice(RequestObj);
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

        [System.Web.Http.Route("VendorInvoice/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(VendorInvoice RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _vendorinvoiceService.UpdateVendorInvoice(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }

        }

        [System.Web.Http.Route("VendorInvoice/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var VendorInvoice = _vendorinvoiceService.GetVendorInvoice(id);
               // VendorInvoice.IsDeleted = 1;
                _vendorinvoiceService.UpdateVendorInvoice(VendorInvoice);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

    }
}



