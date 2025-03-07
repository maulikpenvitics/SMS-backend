 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Vendors;
 using Data.VendorInvoices;


namespace Data.VendorInvoices
{
     public interface IVendorInvoiceService
    {
        List<VendorInvoiceResponseModel> GetVendorInvoices();
        VendorInvoice GetVendorInvoice(int Id);
        void CreateVendorInvoice(VendorInvoice VendorInvoiceObj);
        void UpdateVendorInvoice(VendorInvoice VendorInvoiceObj);
        bool DeleteVendorInvoice(int Id);
        //List<SelectListItem> GetVendorInvoiceDropdown();
         
    }
    public class VendorInvoiceService : IVendorInvoiceService
    {
        
         private readonly IVendorRepository _vendorRepository = new VendorRepository(new DbFactory());
 private readonly IVendorInvoiceRepository _vendorinvoiceRepository = new VendorInvoiceRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VendorInvoiceResponseModel> GetVendorInvoices()
        {
                var VendorInvoiceList = (
                                           from _vendorinvoice in _vendorinvoiceRepository.GetAll()
 join  _vendor in _vendorRepository.GetAll() on  _vendorinvoice.VendorId equals _vendor.Id

                                          select new VendorInvoiceResponseModel
                                          {
                                               Id = _vendorinvoice.Id,
VendorId = _vendor.Id,
vendorName = _vendor.Firstname+" "+_vendor.Lastname,
Invoicedate = _vendorinvoice.Invoicedate,
Todate = _vendorinvoice.Todate,
Amount = _vendorinvoice.Amount,
Duedate = _vendorinvoice.Duedate,
Tax = _vendorinvoice.Tax,
NetAmount = _vendorinvoice.NetAmount,
Modifiedby = _vendorinvoice.Modifiedby,
Modifieddate = _vendorinvoice.Modifieddate,


                                          }).ToList();
                    return VendorInvoiceList;
            

        }
        public VendorInvoice GetVendorInvoice(int Id)
        {
            var Result = _vendorinvoiceRepository.GetById(Id);
            return Result;
        }
        public void CreateVendorInvoice(VendorInvoice VendorInvoiceObj)
        {
            _vendorinvoiceRepository.Add(VendorInvoiceObj);
        }
        public void UpdateVendorInvoice(VendorInvoice VendorInvoiceObj)
        {
            _vendorinvoiceRepository.Update(VendorInvoiceObj);
        }

        public bool DeleteVendorInvoice(int Id)
        {
            var Result = _vendorinvoiceRepository.GetById(Id);
            _vendorinvoiceRepository.Delete(Result);
            return true;
        }
        //public List<SelectListItem> GetVendorInvoiceDropdown()
        //{
        //    var Result = _vendorinvoiceRepository.GetAll().Select(x => new SelectListItem
        //    {
        //        Value = x.Id.ToString() ,
        //        Text = x.Name.ToString() 

        //    }).ToList();
        //    return Result;
        //}
         
    }
}
   


