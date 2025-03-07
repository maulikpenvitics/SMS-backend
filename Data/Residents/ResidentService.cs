 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.Blocks;
 using Data.Residents;
using Data.Units;


namespace Data.Residents
{
     public interface IResidentService
    {
        List<ResidentResponseModel> GetResidents();
        Resident GetResident(int Id);
        void CreateResident(Resident ResidentObj);
        void UpdateResident(Resident ResidentObj);
        bool DeleteResident(int Id);
        List<SelectListItem> GetResidentDropdown();
         
    }
    public class ResidentService : IResidentService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IBlockRepository _blockRepository = new BlockRepository(new DbFactory());
 private readonly IResidentRepository _residentRepository = new ResidentRepository(new DbFactory());
 private readonly IUnitRepository _unitRepository = new UnitRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<ResidentResponseModel> GetResidents()
        {
                var ResidentList = (
                                           from _resident in _residentRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _resident.PropertyId equals _property.Id
 join  _block in _blockRepository.GetAll() on  _resident.BlockId equals _block.Id
 join  _unit in _unitRepository.GetAll() on _resident.UnitId equals _unit.Id

                                          select new ResidentResponseModel
                                          {
                                               Id = _resident.Id,
Username = _resident.Username,
Password = _resident.Password,
Firstname = _resident.Firstname,
Lastname = _resident.Lastname,
Email = _resident.Email,
Phoneno = _resident.Phoneno,
Detailedinfo = _resident.Detailedinfo,
PropertyId = _property.Id,
PropertyName = _property.Propertyname,
BlockId = _block.Id,
Blockname = _block.Blockname,
UnitId = _unit.Id,
Unitname = _unit.Unitname,
Modifiedby = _resident.Modifiedby,
Modifieddate = _resident.Modifieddate,


                                          }).ToList();
                    return ResidentList;
            

        }
        public Resident GetResident(int Id)
        {
            var Result = _residentRepository.GetById(Id);
            return Result;
        }
        public void CreateResident(Resident ResidentObj)
        {
            _residentRepository.Add(ResidentObj);
        }
        public void UpdateResident(Resident ResidentObj)
        {
            _residentRepository.Update(ResidentObj);
        }

        public bool DeleteResident(int Id)
        {
            var Result = _residentRepository.GetById(Id);
            _residentRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetResidentDropdown()
        {
            var Result = _residentRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Firstname+" "+x.Lastname

            }).ToList();
            return Result;
        }
         
    }
}
   


