
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
 using Data.Blocks;
 using Data.Residents;
using Data.Units;


namespace WebAPI.Controllers
{
     public class ResidentController : ApiController
    {
        public readonly IPropertyService _propertyService = new PropertyService();
public readonly IBlockService _blockService = new BlockService();
public readonly IResidentService _residentService = new ResidentService();
        public readonly IUnitService _unitService = new UnitService();


        [System.Web.Http.Route("Resident/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var ResidentList = _residentService.GetResidents();
                return Request.CreateResponse(HttpStatusCode.OK, ResidentList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("Resident/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _residentService.GetResident(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("Resident/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(Resident RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _residentService.CreateResident(RequestObj);
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

        [System.Web.Http.Route("Resident/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(Resident RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _residentService.UpdateResident(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("Resident/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var Resident = _residentService.GetResident(id);
                //Resident.IsDeleted = 1;
                _residentService.UpdateResident(Resident);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


