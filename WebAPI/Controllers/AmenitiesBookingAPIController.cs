
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
 using Data.PropertyAmenitiess;
 using Data.Users;
 using Data.AmenitiesBookings;


namespace WebAPI.Controllers
{
     public class AmenitiesBookingController : ApiController
    {
        public readonly IPropertyService _propertyService = new PropertyService();
     public readonly IPropertyAmenitiesService _propertyamenitiesService = new PropertyAmenitiesService();
public readonly IUserService _userService = new UserService();
public readonly IAmenitiesBookingService _amenitiesbookingService = new AmenitiesBookingService();


        [System.Web.Http.Route("AmenitiesBooking/GetAll")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var AmenitiesBookingList = _amenitiesbookingService.GetAmenitiesBookings();
                return Request.CreateResponse(HttpStatusCode.OK, AmenitiesBookingList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        [System.Web.Http.Route("AmenitiesBooking/GetById")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var Country = _amenitiesbookingService.GetAmenitiesBooking(id);
                return Request.CreateResponse(HttpStatusCode.OK, Country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        }

        [System.Web.Http.Route("AmenitiesBooking/Create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(AmenitiesBooking RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    _amenitiesbookingService.CreateAmenitiesBooking(RequestObj);
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

        [System.Web.Http.Route("AmenitiesBooking/Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(AmenitiesBooking RequestObj)
        {
            try
            {
                if (RequestObj.Id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    _amenitiesbookingService.UpdateAmenitiesBooking(RequestObj);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
            
        } 

        [System.Web.Http.Route("AmenitiesBooking/Delete")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var AmenitiesBooking = _amenitiesbookingService.GetAmenitiesBooking(id);
              //  AmenitiesBooking.IsDeleted = 1;
                _amenitiesbookingService.UpdateAmenitiesBooking(AmenitiesBooking);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
     
    }
}
   


