 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.VendorEmployeeDocs;


namespace Data.VendorEmployeeDocs
{
     public interface IVendorEmployeeDocService
    {
        List<VendorEmployeeDocResponseModel> GetVendorEmployeeDocs();
        VendorEmployeeDoc GetVendorEmployeeDoc(int Id);
        void CreateVendorEmployeeDoc(VendorEmployeeDoc VendorEmployeeDocObj);
        void UpdateVendorEmployeeDoc(VendorEmployeeDoc VendorEmployeeDocObj);
        bool DeleteVendorEmployeeDoc(int Id);
        
         
    }
    public class VendorEmployeeDocService : IVendorEmployeeDocService
    {
        
         private readonly IVendorEmployeeDocRepository _vendoremployeedocRepository = new VendorEmployeeDocRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VendorEmployeeDocResponseModel> GetVendorEmployeeDocs()
        {
                var VendorEmployeeDocList = (
                                           from _vendoremployeedoc in _vendoremployeedocRepository.GetAll()

                                          select new VendorEmployeeDocResponseModel
                                          {
                                               Id = _vendoremployeedoc.Id,
Docurl = _vendoremployeedoc.Docurl,
Doctype = _vendoremployeedoc.Doctype,
VendorEmployeeId = _vendoremployeedoc.VendorEmployeeId,
Modifiedby = _vendoremployeedoc.Modifiedby,
Modifieddate = _vendoremployeedoc.Modifieddate,


                                          }).ToList();
                    return VendorEmployeeDocList;
            

        }
        public VendorEmployeeDoc GetVendorEmployeeDoc(int Id)
        {
            var Result = _vendoremployeedocRepository.GetById(Id);
            return Result;
        }
        public void CreateVendorEmployeeDoc(VendorEmployeeDoc VendorEmployeeDocObj)
        {
            _vendoremployeedocRepository.Add(VendorEmployeeDocObj);
        }
        public void UpdateVendorEmployeeDoc(VendorEmployeeDoc VendorEmployeeDocObj)
        {
            _vendoremployeedocRepository.Update(VendorEmployeeDocObj);
        }

        public bool DeleteVendorEmployeeDoc(int Id)
        {
            var Result = _vendoremployeedocRepository.GetById(Id);
            _vendoremployeedocRepository.Delete(Result);
            return true;
        }
     
         
    }
}
   


