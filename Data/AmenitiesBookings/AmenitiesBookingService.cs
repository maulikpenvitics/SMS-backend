 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Propertys;
using Data.Users;
using Data.AmenitiesBookings;
using Data.PropertyAmenitiess;


namespace Data.AmenitiesBookings
{
     public interface IAmenitiesBookingService
    {
        List<AmenitiesBookingResponseModel> GetAmenitiesBookings();
        AmenitiesBooking GetAmenitiesBooking(int Id);
        void CreateAmenitiesBooking(AmenitiesBooking AmenitiesBookingObj);
        void UpdateAmenitiesBooking(AmenitiesBooking AmenitiesBookingObj);
        bool DeleteAmenitiesBooking(int Id);
      
         
    }
    public class AmenitiesBookingService : IAmenitiesBookingService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IPropertyAmenitiesRepository _propertyamenitiesRepository = new PropertyAmenitiesRepository(new DbFactory());
 private readonly IUserRepository _userRepository = new UserRepository(new DbFactory());
 private readonly IAmenitiesBookingRepository _amenitiesbookingRepository = new AmenitiesBookingRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<AmenitiesBookingResponseModel> GetAmenitiesBookings()
        {
                var AmenitiesBookingList = (
                                           from _amenitiesbooking in _amenitiesbookingRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _amenitiesbooking.PropertyId equals _property.Id
 join  _propertyamenities in _propertyamenitiesRepository.GetAll() on  _amenitiesbooking.PropertyAmenitiesId equals _propertyamenities.Id
 join  _user in _userRepository.GetAll() on  _amenitiesbooking.UserId equals _user.Id

                                          select new AmenitiesBookingResponseModel
                                          {
                                               Id = _amenitiesbooking.Id,
PropertyId = _property.Id,
PropertyName = _property.Propertyname,
PropertyAmenitiesId = _propertyamenities.Id,
propertyamenitiesName = _propertyamenities.Amenityname,
UserId = _user.Id,
UserName = _user.Username,
Amenitiesstatus = _amenitiesbooking.Amenitiesstatus,
Availabilitytimeslots = _amenitiesbooking.Availabilitytimeslots,
Bokingpurpose = _amenitiesbooking.Bokingpurpose,
Checkintime = _amenitiesbooking.Checkintime,
Checkouttime = _amenitiesbooking.Checkouttime,
Modifiedby = _amenitiesbooking.Modifiedby,
Modifieddate = _amenitiesbooking.Modifieddate,


                                          }).ToList();
                    return AmenitiesBookingList;
            

        }
        public AmenitiesBooking GetAmenitiesBooking(int Id)
        {
            var Result = _amenitiesbookingRepository.GetById(Id);
            return Result;
        }
        public void CreateAmenitiesBooking(AmenitiesBooking AmenitiesBookingObj)
        {
            _amenitiesbookingRepository.Add(AmenitiesBookingObj);
        }
        public void UpdateAmenitiesBooking(AmenitiesBooking AmenitiesBookingObj)
        {
            _amenitiesbookingRepository.Update(AmenitiesBookingObj);
        }

        public bool DeleteAmenitiesBooking(int Id)
        {
            var Result = _amenitiesbookingRepository.GetById(Id);
            _amenitiesbookingRepository.Delete(Result);
            return true;
        }
     
         
    }
}
   


