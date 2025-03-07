 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Visitors;
 using Data.Directorys;


namespace Data.Directorys
{
     public interface IDirectoryService
    {
        List<DirectoryResponseModel> GetDirectorys();
        Directory GetDirectory(int Id);
        void CreateDirectory(Directory DirectoryObj);
        void UpdateDirectory(Directory DirectoryObj);
        bool DeleteDirectory(int Id);
      
         
    }
    public class DirectoryService : IDirectoryService
    {
        
         private readonly IVisitorRepository _visitorRepository = new VisitorRepository(new DbFactory());
 private readonly IDirectoryRepository _directoryRepository = new DirectoryRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<DirectoryResponseModel> GetDirectorys()
        {
                var DirectoryList = (
                                           from _directory in _directoryRepository.GetAll()
 join  _visitor in _visitorRepository.GetAll() on  _directory.VisitorId equals _visitor.Id

                                          select new DirectoryResponseModel
                                          {
                                               Id = _directory.Id,
Discription = _directory.Discription,
Bussinessid = _directory.Bussinessid,
VisitorId = _visitor.Id,
VisitorName = _visitor.Firstname+" "+_visitor.Lastname,
Modifiedby = _directory.Modifiedby,
Modifieddate = _directory.Modifieddate,


                                          }).ToList();
                    return DirectoryList;
            

        }
        public Directory GetDirectory(int Id)
        {
            var Result = _directoryRepository.GetById(Id);
            return Result;
        }
        public void CreateDirectory(Directory DirectoryObj)
        {
            _directoryRepository.Add(DirectoryObj);
        }
        public void UpdateDirectory(Directory DirectoryObj)
        {
            _directoryRepository.Update(DirectoryObj);
        }

        public bool DeleteDirectory(int Id)
        {
            var Result = _directoryRepository.GetById(Id);
            _directoryRepository.Delete(Result);
            return true;
        }
      
         
    }
}
   


