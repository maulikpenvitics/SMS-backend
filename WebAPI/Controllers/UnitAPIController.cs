using Domain.Entities;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Data.Propertys;
using Data.Units;
using Data.Blocks;

namespace WebAPI.Controllers
{
    public class UnitController : ApiController
    {
        public readonly IBlockService _blockService = new BlockService();
        public readonly IUnitService _unitService = new UnitService();

        [System.Web.Http.Route("Unit/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var UnitList = _unitService.GetUnits();
                return Request.CreateResponse(HttpStatusCode.OK, UnitList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("Unit/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Unit = _unitService.GetUnit(id);
                return Request.CreateResponse(HttpStatusCode.OK, Unit);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("Unit/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(Unit RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _unitService.CreateUnit(RequestObj);
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

        [System.Web.Http.Route("Unit/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(Unit RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _unitService.UpdateUnit(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("Unit/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var Unit = _unitService.GetUnit(id);
                _unitService.UpdateUnit(Unit);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
    }
}
