
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
 using Data.Services;
 using Data.Vendors;
 using Data.SupportTickets;
using Data.Users;
using Data.Units;


namespace WebAPI.Controllers
{
     public class SupportTicketController : ApiController
    {
          public readonly IServiceService _serviceService = new ServiceService();
public readonly IVendorService _vendorService = new Data.Vendors.VendorService();
public readonly ISupportTicketService _supportticketService = new SupportTicketService();
        public readonly IUserService _userService = new UserService();


        [System.Web.Http.Route("SupportTicket/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var SupportTicketList = _supportticketService.GetSupportTickets();
                return Request.CreateResponse(HttpStatusCode.OK, SupportTicketList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("SupportTicket/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _supportticketService.GetSupportTicket(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("SupportTicket/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(SupportTicket RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _supportticketService.CreateSupportTicket(RequestObj);
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

        [System.Web.Http.Route("SupportTicket/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(SupportTicket RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _supportticketService.UpdateSupportTicket(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("SupportTicket/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var SupportTicket = _supportticketService.GetSupportTicket(id);
                //SupportTicket.IsDeleted = 1;
                _supportticketService.UpdateSupportTicket(SupportTicket);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


