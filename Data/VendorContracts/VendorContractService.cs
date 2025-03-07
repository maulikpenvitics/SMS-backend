 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Data.VendorContracts;
using Data.Vendors;


namespace Data.VendorContracts
{
     public interface IVendorContractService
    {
        List<VendorContractResponseModel> GetVendorContracts();
        VendorContract GetVendorContract(int Id);
        void CreateVendorContract(VendorContract VendorContractObj);
        void UpdateVendorContract(VendorContract VendorContractObj);
        bool DeleteVendorContract(int Id);
        //List<SelectListItem> GetVendorContractDropdown();
         
    }
    public class VendorContractService : IVendorContractService
    {
        
 private readonly IVendorRepository _vendorRepository = new VendorRepository(new DbFactory());
 private readonly IVendorContractRepository _vendorcontractRepository = new VendorContractRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VendorContractResponseModel> GetVendorContracts()
        {
                var VendorContractList = (
                                           from _vendorcontract in _vendorcontractRepository.GetAll()
 join  _vendor in _vendorRepository.GetAll() on  _vendorcontract.VendorId equals _vendor.Id

                                          select new VendorContractResponseModel
                                          {
                                               Id = _vendorcontract.Id,
VendorId = _vendor.Id,
vendorName = _vendor.Firstname + " " + _vendor.Lastname,
Contracturl = _vendorcontract.Contracturl,
Fromdate = _vendorcontract.Fromdate,
Todate = _vendorcontract.Todate,
Amount = _vendorcontract.Amount,
Paymentcycle = _vendorcontract.Paymentcycle,
Modifiedby = _vendorcontract.Modifiedby,
Modifieddate = _vendorcontract.Modifieddate,


                                          }).ToList();
                    return VendorContractList;
            

        }
        public VendorContract GetVendorContract(int Id)
        {
            var Result = _vendorcontractRepository.GetById(Id);
            return Result;
        }
        public void CreateVendorContract(VendorContract VendorContractObj)
        {
            _vendorcontractRepository.Add(VendorContractObj);
        }
        public void UpdateVendorContract(VendorContract VendorContractObj)
        {
            _vendorcontractRepository.Update(VendorContractObj);
        }

        public bool DeleteVendorContract(int Id)
        {
            var Result = _vendorcontractRepository.GetById(Id);
            _vendorcontractRepository.Delete(Result);
            return true;
        }
        //public List<SelectListItem> GetVendorContractDropdown()
        //{
        //    var Result = _vendorcontractRepository.GetAll().Select(x => new SelectListItem
        //    {
        //        Value = x.Id.ToString() ,
        //        Text = x.Name.ToString() 

        //    }).ToList();
        //    return Result;
        //}
         
    }
}
   


