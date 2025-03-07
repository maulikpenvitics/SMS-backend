
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
 using Data.VisitorVisits;


namespace WebAPI.Controllers
{
     public class VisitorVisitController : ApiController
    {
        public readonly IVisitorVisitService _visitorvisitService = new VisitorVisitService();


        [System.Web.Http.Route("VisitorVisit/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var VisitorVisitList = _visitorvisitService.GetVisitorVisits();
                return Request.CreateResponse(HttpStatusCode.OK, VisitorVisitList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("VisitorVisit/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _visitorvisitService.GetVisitorVisit(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("VisitorVisit/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(VisitorVisit RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _visitorvisitService.CreateVisitorVisit(RequestObj);
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

        [System.Web.Http.Route("VisitorVisit/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(VisitorVisit RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _visitorvisitService.UpdateVisitorVisit(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("VisitorVisit/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var VisitorVisit = _visitorvisitService.GetVisitorVisit(id);
               // VisitorVisit.IsDeleted = 1;
                _visitorvisitService.UpdateVisitorVisit(VisitorVisit);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


