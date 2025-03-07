
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
 using Data.Vendors;
 using Data.Accountings;
using Data.Users;


namespace WebAPI.Controllers
{
     public class AccountingController : ApiController
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IVendorService _vendorService = new Data.Vendors.VendorService();
public readonly IAccountingService _accountingService = new AccountingService();
        public readonly IUserService _userService = new UserService();


        [System.Web.Http.Route("Accounting/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var AccountingList = _accountingService.GetAccountings();
                return Request.CreateResponse(HttpStatusCode.OK, AccountingList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("Accounting/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _accountingService.GetAccounting(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("Accounting/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(Accounting RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _accountingService.CreateAccounting(RequestObj);
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

        [System.Web.Http.Route("Accounting/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(Accounting RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _accountingService.UpdateAccounting(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("Accounting/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var Accounting = _accountingService.GetAccounting(id);
                //Accounting.IsDeleted = 1;
                _accountingService.UpdateAccounting(Accounting);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


