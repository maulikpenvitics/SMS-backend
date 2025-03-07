 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Visitors;


namespace Data.Visitors
{
     public interface IVisitorService
    {
        List<VisitorResponseModel> GetVisitors();
        Visitor GetVisitor(int Id);
        void CreateVisitor(Visitor VisitorObj);
        void UpdateVisitor(Visitor VisitorObj);
        bool DeleteVisitor(int Id);
        List<SelectListItem> GetVisitorDropdown();
         
    }
    public class VisitorService : IVisitorService
    {
        
         private readonly IVisitorRepository _visitorRepository = new VisitorRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<VisitorResponseModel> GetVisitors()
        {
                var VisitorList = (
                                           from _visitor in _visitorRepository.GetAll()

                                          select new VisitorResponseModel
                                          {
                                               Id = _visitor.Id,
Firstname = _visitor.Firstname,
Lastname = _visitor.Lastname,
Idno = _visitor.Idno,
Idtype = _visitor.Idtype,
Gatepass = _visitor.Gatepass,
Phoneno = _visitor.Phoneno,
Modifiedby = _visitor.Modifiedby,
Modifieddate = _visitor.Modifieddate,


                                          }).ToList();
                    return VisitorList;
            

        }
        public Visitor GetVisitor(int Id)
        {
            var Result = _visitorRepository.GetById(Id);
            return Result;
        }
        public void CreateVisitor(Visitor VisitorObj)
        {
            _visitorRepository.Add(VisitorObj);
        }
        public void UpdateVisitor(Visitor VisitorObj)
        {
            _visitorRepository.Update(VisitorObj);
        }

        public bool DeleteVisitor(int Id)
        {
            var Result = _visitorRepository.GetById(Id);
            _visitorRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetVisitorDropdown()
        {
            var Result = _visitorRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Firstname+" "+x.Lastname 

            }).ToList();
            return Result;
        }
         
    }
}
   


