 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Billings;


namespace Data.Billings
{
     public interface IBillingService
    {
        List<BillingResponseModel> GetBillings();
        Billing GetBilling(int Id);
        void CreateBilling(Billing BillingObj);
        void UpdateBilling(Billing BillingObj);
        bool DeleteBilling(int Id);
      
         
    }
    public class BillingService : IBillingService
    {
        
         private readonly IBillingRepository _billingRepository = new BillingRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<BillingResponseModel> GetBillings()
        {
                var BillingList = (
                                           from _billing in _billingRepository.GetAll()

                                          select new BillingResponseModel
                                          {
                                               Id = _billing.Id,
Debitaccountid = _billing.Debitaccountid,
Modifiedby = _billing.Modifiedby,
Modifieddate = _billing.Modifieddate,


                                          }).ToList();
                    return BillingList;
            

        }
        public Billing GetBilling(int Id)
        {
            var Result = _billingRepository.GetById(Id);
            return Result;
        }
        public void CreateBilling(Billing BillingObj)
        {
            _billingRepository.Add(BillingObj);
        }
        public void UpdateBilling(Billing BillingObj)
        {
            _billingRepository.Update(BillingObj);
        }

        public bool DeleteBilling(int Id)
        {
            var Result = _billingRepository.GetById(Id);
            _billingRepository.Delete(Result);
            return true;
        }
       
         
    }
}
   


