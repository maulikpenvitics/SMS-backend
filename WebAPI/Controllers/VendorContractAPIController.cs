
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
 using Data.VendorContracts;


namespace WebAPI.Controllers
{
     public class VendorContractController : ApiController
    {
         public readonly IVendorService _vendorService = new Data.Vendors.VendorService();
public readonly IVendorContractService _vendorcontractService = new VendorContractService();


        [System.Web.Http.Route("VendorContract/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var VendorContractList = _vendorcontractService.GetVendorContracts();
                return Request.CreateResponse(HttpStatusCode.OK, VendorContractList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("VendorContract/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _vendorcontractService.GetVendorContract(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("VendorContract/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(VendorContract RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _vendorcontractService.CreateVendorContract(RequestObj);
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

        [System.Web.Http.Route("VendorContract/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(VendorContract RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _vendorcontractService.UpdateVendorContract(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("VendorContract/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var VendorContract = _vendorcontractService.GetVendorContract(id);
               // VendorContract.IsDeleted = 1;
                _vendorcontractService.UpdateVendorContract(VendorContract);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


