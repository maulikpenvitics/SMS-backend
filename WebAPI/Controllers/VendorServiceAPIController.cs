
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
using Data.Services;
using Data.VendorServices;
using VendorService = Domain.Entities.VendorService;


namespace WebAPI.Controllers
{
    public class VendorServiceController : ApiController
    {
        public readonly IVendorService _vendorService = new Data.Vendors.VendorService();
        public readonly IServiceService _serviceService = new ServiceService();
        public readonly IVendorServiceService _vendorserviceService = new VendorServiceService();


        [System.Web.Http.Route("VendorService/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var VendorServiceList = _vendorserviceService.GetVendorServices();
                return Request.CreateResponse(HttpStatusCode.OK, VendorServiceList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("VendorService/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _vendorserviceService.GetVendorService(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }

        }

        [System.Web.Http.Route("VendorService/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(VendorService RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _vendorserviceService.CreateVendorService(RequestObj);
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

        [System.Web.Http.Route("VendorService/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(VendorService RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _vendorserviceService.UpdateVendorService(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }

        }

        [System.Web.Http.Route("VendorService/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var VendorService = _vendorserviceService.GetVendorService(id);
              //  VendorService.IsDeleted = 1;
                _vendorserviceService.UpdateVendorService(VendorService);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

    }
}



