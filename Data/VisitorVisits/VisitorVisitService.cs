 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.VisitorVisits;


namespace Data.VisitorVisits
{
     public interface IVisitorVisitService
    {
        List<VisitorVisitResponseModel> GetVisitorVisits();
        VisitorVisit GetVisitorVisit(int Id);
        void CreateVisitorVisit(VisitorVisit VisitorVisitObj);
        void UpdateVisitorVisit(VisitorVisit VisitorVisitObj);
        bool DeleteVisitorVisit(int Id);
      
         
    }
    public class VisitorVisitService : IVisitorVisitService
    {
        
         private readonly IVisitorVisitRepository _visitorvisitRepository = new VisitorVisitRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VisitorVisitResponseModel> GetVisitorVisits()
        {
                var VisitorVisitList = (
                                           from _visitorvisit in _visitorvisitRepository.GetAll()

                                          select new VisitorVisitResponseModel
                                          {
                                               Id = _visitorvisit.Id,
VisitorId = _visitorvisit.VisitorId,
Checkin = _visitorvisit.Checkin,
Checkout = _visitorvisit.Checkout,
BlockId = _visitorvisit.BlockId,
Unit = _visitorvisit.Unit,
Gatepass = _visitorvisit.Gatepass,
UserId = _visitorvisit.UserId,
Purpose = _visitorvisit.Purpose,
Modifiedby = _visitorvisit.Modifiedby,
Modifieddate = _visitorvisit.Modifieddate,


                                          }).ToList();
                    return VisitorVisitList;
            

        }
        public VisitorVisit GetVisitorVisit(int Id)
        {
            var Result = _visitorvisitRepository.GetById(Id);
            return Result;
        }
        public void CreateVisitorVisit(VisitorVisit VisitorVisitObj)
        {
            _visitorvisitRepository.Add(VisitorVisitObj);
        }
        public void UpdateVisitorVisit(VisitorVisit VisitorVisitObj)
        {
            _visitorvisitRepository.Update(VisitorVisitObj);
        }

        public bool DeleteVisitorVisit(int Id)
        {
            var Result = _visitorvisitRepository.GetById(Id);
            _visitorvisitRepository.Delete(Result);
            return true;
        }
      
         
    }
}
   


