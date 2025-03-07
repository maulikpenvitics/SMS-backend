 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.VendorEmployeeRoles;


namespace Data.VendorEmployeeRoles
{
     public interface IVendorEmployeeRoleService
    {
        List<VendorEmployeeRoleResponseModel> GetVendorEmployeeRoles();
        VendorEmployeeRole GetVendorEmployeeRole(int Id);
        void CreateVendorEmployeeRole(VendorEmployeeRole VendorEmployeeRoleObj);
        void UpdateVendorEmployeeRole(VendorEmployeeRole VendorEmployeeRoleObj);
        bool DeleteVendorEmployeeRole(int Id);
        List<SelectListItem> GetVendorEmployeeRoleDropdown();
         
    }
    public class VendorEmployeeRoleService : IVendorEmployeeRoleService
    {
        
         private readonly IVendorEmployeeRoleRepository _vendoremployeeroleRepository = new VendorEmployeeRoleRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VendorEmployeeRoleResponseModel> GetVendorEmployeeRoles()
        {
                var VendorEmployeeRoleList = (
                                           from _vendoremployeerole in _vendoremployeeroleRepository.GetAll()

                                          select new VendorEmployeeRoleResponseModel
                                          {
                                               Id = _vendoremployeerole.Id,
Name = _vendoremployeerole.Name,
Modifiedby = _vendoremployeerole.Modifiedby,
Modifieddate = _vendoremployeerole.Modifieddate,


                                          }).ToList();
                    return VendorEmployeeRoleList;
            

        }
        public VendorEmployeeRole GetVendorEmployeeRole(int Id)
        {
            var Result = _vendoremployeeroleRepository.GetById(Id);
            return Result;
        }
        public void CreateVendorEmployeeRole(VendorEmployeeRole VendorEmployeeRoleObj)
        {
            _vendoremployeeroleRepository.Add(VendorEmployeeRoleObj);
        }
        public void UpdateVendorEmployeeRole(VendorEmployeeRole VendorEmployeeRoleObj)
        {
            _vendoremployeeroleRepository.Update(VendorEmployeeRoleObj);
        }

        public bool DeleteVendorEmployeeRole(int Id)
        {
            var Result = _vendoremployeeroleRepository.GetById(Id);
            _vendoremployeeroleRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetVendorEmployeeRoleDropdown()
        {
            var Result = _vendoremployeeroleRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Name.ToString() 

            }).ToList();
            return Result;
        }
         
    }
}
   


