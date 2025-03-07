
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
 using Data.Visitors;
 using Data.Directorys;


namespace WebAPI.Controllers
{
     public class DirectoryController : ApiController
    {
        public readonly IVisitorService _visitorService = new VisitorService();
public readonly IDirectoryService _directoryService = new DirectoryService();


        [System.Web.Http.Route("Directory/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var DirectoryList = _directoryService.GetDirectorys();
                return Request.CreateResponse(HttpStatusCode.OK, DirectoryList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("Directory/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _directoryService.GetDirectory(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("Directory/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(Directory RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _directoryService.CreateDirectory(RequestObj);
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

        [System.Web.Http.Route("Directory/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(Directory RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _directoryService.UpdateDirectory(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("Directory/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var Directory = _directoryService.GetDirectory(id);
                //Directory.IsDeleted = 1;
                _directoryService.UpdateDirectory(Directory);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


