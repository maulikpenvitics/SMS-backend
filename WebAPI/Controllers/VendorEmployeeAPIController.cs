
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
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.VendorEmployees;


namespace WebAPI.Controllers
{
     public class VendorEmployeeController : ApiController
    {
         public readonly IVendorService _vendorService = new Data.Vendors.VendorService();
public readonly ICityService _cityService = new CityService();
public readonly IStateService _stateService = new StateService();
public readonly ICountryService _countryService = new CountryService();
public readonly IVendorEmployeeService _vendoremployeeService = new VendorEmployeeService();


        [System.Web.Http.Route("VendorEmployee/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var VendorEmployeeList = _vendoremployeeService.GetVendorEmployees();
                return Request.CreateResponse(HttpStatusCode.OK, VendorEmployeeList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("VendorEmployee/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _vendoremployeeService.GetVendorEmployee(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("VendorEmployee/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(VendorEmployee RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _vendoremployeeService.CreateVendorEmployee(RequestObj);
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

        [System.Web.Http.Route("VendorEmployee/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(VendorEmployee RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _vendoremployeeService.UpdateVendorEmployee(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("VendorEmployee/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var VendorEmployee = _vendoremployeeService.GetVendorEmployee(id);
              //  VendorEmployee.IsDeleted = 1;
                _vendoremployeeService.UpdateVendorEmployee(VendorEmployee);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


