using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Propertys;
using Data.Units;
using Data.Blocks;

namespace Data.Units
{
    public interface IUnitService
    {
        List<UnitResponseModel> GetUnits();
        Unit GetUnit(int Id);
        void CreateUnit(Unit UnitObj);
        void UpdateUnit(Unit UnitObj);
        bool DeleteUnit(int Id);
        List<SelectListItem> GetUnitDropdown();
    }

    public class UnitService : IUnitService
    {
        private readonly IBlockRepository _blockRepository = new BlockRepository(new DbFactory());
        private readonly IUnitRepository _unitRepository = new UnitRepository(new DbFactory());
        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());

        public List<UnitResponseModel> GetUnits()
        {
            var UnitList = new List<UnitResponseModel>();
            try
            {
                 UnitList = (
                from _unit in _unitRepository.GetAll()
                join _block in _blockRepository.GetAll() on _unit.BlockId equals _block.Id
                select new UnitResponseModel
                {
                    Id = _unit.Id,
                    Unitname = _unit.Unitname,
                    BlockId = _block.Id
                }).ToList();
            }
            catch(Exception ex)
            {

            }
            

            return UnitList;
        }

        public Unit GetUnit(int Id)
        {
            return _unitRepository.GetById(Id);
        }

        public void CreateUnit(Unit UnitObj)
        {
            _unitRepository.Add(UnitObj);
        }

        public void UpdateUnit(Unit UnitObj)
        {
            _unitRepository.Update(UnitObj);
        }

        public bool DeleteUnit(int Id)
        {
            var Result = _unitRepository.GetById(Id);
            _unitRepository.Delete(Result);
            return true;
        }

        public List<SelectListItem> GetUnitDropdown()
        {
            return _unitRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Unitname.ToString()
            }).ToList();
        }
    }
}
