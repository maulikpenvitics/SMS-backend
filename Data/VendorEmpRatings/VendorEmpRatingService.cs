 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.VendorEmployees;
 using Data.VendorEmpRatings;


namespace Data.VendorEmpRatings
{
     public interface IVendorEmpRatingService
    {
        List<VendorEmpRatingResponseModel> GetVendorEmpRatings();
        VendorEmpRating GetVendorEmpRating(int Id);
        void CreateVendorEmpRating(VendorEmpRating VendorEmpRatingObj);
        void UpdateVendorEmpRating(VendorEmpRating VendorEmpRatingObj);
        bool DeleteVendorEmpRating(int Id);
      
         
    }
    public class VendorEmpRatingService : IVendorEmpRatingService
    {
        
         private readonly IVendorEmployeeRepository _vendoremployeeRepository = new VendorEmployeeRepository(new DbFactory());
 private readonly IVendorEmpRatingRepository _vendorempratingRepository = new VendorEmpRatingRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VendorEmpRatingResponseModel> GetVendorEmpRatings()
        {
                var VendorEmpRatingList = (
                                           from _vendoremprating in _vendorempratingRepository.GetAll()
 join  _vendoremployee in _vendoremployeeRepository.GetAll() on  _vendoremprating.VendorEmployeeId equals _vendoremployee.VendorEmployeeId

                                          select new VendorEmpRatingResponseModel
                                          {
                                               Id = _vendoremprating.Id,
Overallrating = _vendoremprating.Overallrating,
VendorEmployeeId = _vendoremployee.VendorEmployeeId,
VendorEmployeeName = _vendoremployee.Firstname+" "+ _vendoremployee.Lastname,
Modifiedby = _vendoremprating.Modifiedby,
Modifieddate = _vendoremprating.Modifieddate,


                                          }).ToList();
                    return VendorEmpRatingList;
            

        }
        public VendorEmpRating GetVendorEmpRating(int Id)
        {
            var Result = _vendorempratingRepository.GetById(Id);
            return Result;
        }
        public void CreateVendorEmpRating(VendorEmpRating VendorEmpRatingObj)
        {
            _vendorempratingRepository.Add(VendorEmpRatingObj);
        }
        public void UpdateVendorEmpRating(VendorEmpRating VendorEmpRatingObj)
        {
            _vendorempratingRepository.Update(VendorEmpRatingObj);
        }

        public bool DeleteVendorEmpRating(int Id)
        {
            var Result = _vendorempratingRepository.GetById(Id);
            _vendorempratingRepository.Delete(Result);
            return true;
        }
       
         
    }
}
   


