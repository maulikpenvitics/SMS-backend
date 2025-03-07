 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.Vendors;
using Data.Users;
 using Data.Accountings;
using Data.Units;


namespace Data.Accountings
{
     public interface IAccountingService
    {
        List<AccountingResponseModel> GetAccountings();
        Accounting GetAccounting(int Id);
        void CreateAccounting(Accounting AccountingObj);
        void UpdateAccounting(Accounting AccountingObj);
        bool DeleteAccounting(int Id);
        List<SelectListItem> GetAccountingDropdown();
         

    }
    public class AccountingService : IAccountingService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IVendorRepository _vendorRepository = new VendorRepository(new DbFactory());
 private readonly IAccountingRepository _accountingRepository = new AccountingRepository(new DbFactory());
        private readonly IUserRepository _userRepository = new UserRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<AccountingResponseModel> GetAccountings()
        {
                var AccountingList = (
                                           from _accounting in _accountingRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _accounting.PropertyId equals _property.Id
 join  _vendor in _vendorRepository.GetAll() on  _accounting.VendorId equals _vendor.Id
 join  _user in _userRepository.GetAll() on  _accounting.UserId equals _user.Id

                                          select new AccountingResponseModel
                                          {
                                               Id = _accounting.Id,
Accountname = _accounting.Accountname,
UserId = _user.Id,
Username = _user.Username,
PropertyId = _property.Id,
Propertyname = _property.Propertyname,
VendorId = _vendor.Id,
Vendorname = _vendor.Firstname+" "+ _vendor.Lastname,
Accountid = _accounting.Accountid,
Accountno = _accounting.Accountno,
Balance = _accounting.Balance,
Entitytype = _accounting.Entitytype,
Modifiedby = _accounting.Modifiedby,
Modifieddate = _accounting.Modifieddate,


                                          }).ToList();
                    return AccountingList;
            

        }
        public Accounting GetAccounting(int Id)
        {
            var Result = _accountingRepository.GetById(Id);
            return Result;
        }
        public void CreateAccounting(Accounting AccountingObj)
        {
            _accountingRepository.Add(AccountingObj);
        }
        public void UpdateAccounting(Accounting AccountingObj)
        {
            _accountingRepository.Update(AccountingObj);
        }

        public bool DeleteAccounting(int Id)
        {
            var Result = _accountingRepository.GetById(Id);
            _accountingRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetAccountingDropdown()
        {
            var Result = _accountingRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Accountname.ToString() 

            }).ToList();
            return Result;
        }
         
    }
}
   


