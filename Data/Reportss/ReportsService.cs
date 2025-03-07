 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Reportss;


namespace Data.Reportss
{
     public interface IReportsService
    {
        List<ReportsResponseModel> GetReportss();
        Reports GetReports(int Id);
        void CreateReports(Reports ReportsObj);
        void UpdateReports(Reports ReportsObj);
        bool DeleteReports(int Id);
        List<SelectListItem> GetReportsDropdown();
         
    }
    public class ReportsService : IReportsService
    {
        
         private readonly IReportsRepository _reportsRepository = new ReportsRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<ReportsResponseModel> GetReportss()
        {
                var ReportsList = (
                                           from _reports in _reportsRepository.GetAll()

                                          select new ReportsResponseModel
                                          {
                                               Id = _reports.Id,
Name = _reports.Name,
Modifiedby = _reports.Modifiedby,
Modifieddate = _reports.Modifieddate,


                                          }).ToList();
                    return ReportsList;
            

        }
        public Reports GetReports(int Id)
        {
            var Result = _reportsRepository.GetById(Id);
            return Result;
        }
        public void CreateReports(Reports ReportsObj)
        {
            _reportsRepository.Add(ReportsObj);
        }
        public void UpdateReports(Reports ReportsObj)
        {
            _reportsRepository.Update(ReportsObj);
        }

        public bool DeleteReports(int Id)
        {
            var Result = _reportsRepository.GetById(Id);
            _reportsRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetReportsDropdown()
        {
            var Result = _reportsRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Name.ToString() 

            }).ToList();
            return Result;
        }
         
    }
}
   


