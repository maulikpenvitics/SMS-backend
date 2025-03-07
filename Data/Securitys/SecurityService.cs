 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Residents;
 using Data.Users;
 using Data.Vendors;
 using Data.Securitys;


namespace Data.Securitys
{
     public interface ISecurityService
    {
        List<SecurityResponseModel> GetSecuritys();
        Security GetSecurity(int Id);
        void CreateSecurity(Security SecurityObj);
        void UpdateSecurity(Security SecurityObj);
        bool DeleteSecurity(int Id);
     
         
    }
    public class SecurityService : ISecurityService
    {
        
         private readonly IResidentRepository _residentRepository = new ResidentRepository(new DbFactory());
 private readonly IUserRepository _userRepository = new UserRepository(new DbFactory());
 private readonly IVendorRepository _vendorRepository = new VendorRepository(new DbFactory());
 private readonly ISecurityRepository _securityRepository = new SecurityRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<SecurityResponseModel> GetSecuritys()
        {
                var SecurityList = (
                                           from _security in _securityRepository.GetAll()
 join  _resident in _residentRepository.GetAll() on  _security.ResidentId equals _resident.Id
 join  _user in _userRepository.GetAll() on  _security.UserId equals _user.Id
 join  _vendor in _vendorRepository.GetAll() on  _security.VendorId equals _vendor.Id

                                          select new SecurityResponseModel
                                          {
                                               Id = _security.Id,
ResidentId = _resident.Id,
ResidentName = _resident.Firstname+" "+_resident.Lastname,
UserId = _user.Id,
UserName = _user.Firstname + " " + _user.Lastname,
VendorId = _vendor.Id,
VendorName = _vendor.Firstname + " " + _vendor.Lastname,
Incidence = _security.Incidence,
Securitydesc = _security.Securitydesc,
Modifiedby = _security.Modifiedby,
Modifieddate = _security.Modifieddate,


                                          }).ToList();
                    return SecurityList;
            

        }
        public Security GetSecurity(int Id)
        {
            var Result = _securityRepository.GetById(Id);
            return Result;
        }
        public void CreateSecurity(Security SecurityObj)
        {
            _securityRepository.Add(SecurityObj);
        }
        public void UpdateSecurity(Security SecurityObj)
        {
            _securityRepository.Update(SecurityObj);
        }

        public bool DeleteSecurity(int Id)
        {
            var Result = _securityRepository.GetById(Id);
            _securityRepository.Delete(Result);
            return true;
        }
      
         
    }
}
   


