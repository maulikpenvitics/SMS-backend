 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.VendorInvoiceDetails;


namespace Data.VendorInvoiceDetails
{
     public interface IVendorInvoiceDetailService
    {
        List<VendorInvoiceDetailResponseModel> GetVendorInvoiceDetails();
        VendorInvoiceDetail GetVendorInvoiceDetail(int Id);
        void CreateVendorInvoiceDetail(VendorInvoiceDetail VendorInvoiceDetailObj);
        void UpdateVendorInvoiceDetail(VendorInvoiceDetail VendorInvoiceDetailObj);
        bool DeleteVendorInvoiceDetail(int Id);
     
         
    }
    public class VendorInvoiceDetailService : IVendorInvoiceDetailService
    {
        
         private readonly IVendorInvoiceDetailRepository _vendorinvoicedetailRepository = new VendorInvoiceDetailRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VendorInvoiceDetailResponseModel> GetVendorInvoiceDetails()
        {
                var VendorInvoiceDetailList = (
                                           from _vendorinvoicedetail in _vendorinvoicedetailRepository.GetAll()

                                          select new VendorInvoiceDetailResponseModel
                                          {
                                               Id = _vendorinvoicedetail.Id,
VendorInvoiceId = _vendorinvoicedetail.VendorInvoiceId,
Lineitem = _vendorinvoicedetail.Lineitem,
Amount = _vendorinvoicedetail.Amount,
Description = _vendorinvoicedetail.Description,
Modifiedby = _vendorinvoicedetail.Modifiedby,
Modifieddate = _vendorinvoicedetail.Modifieddate,


                                          }).ToList();
                    return VendorInvoiceDetailList;
            

        }
        public VendorInvoiceDetail GetVendorInvoiceDetail(int Id)
        {
            var Result = _vendorinvoicedetailRepository.GetById(Id);
            return Result;
        }
        public void CreateVendorInvoiceDetail(VendorInvoiceDetail VendorInvoiceDetailObj)
        {
            _vendorinvoicedetailRepository.Add(VendorInvoiceDetailObj);
        }
        public void UpdateVendorInvoiceDetail(VendorInvoiceDetail VendorInvoiceDetailObj)
        {
            _vendorinvoicedetailRepository.Update(VendorInvoiceDetailObj);
        }

        public bool DeleteVendorInvoiceDetail(int Id)
        {
            var Result = _vendorinvoicedetailRepository.GetById(Id);
            _vendorinvoicedetailRepository.Delete(Result);
            return true;
        }
    
         
    }
}
   


