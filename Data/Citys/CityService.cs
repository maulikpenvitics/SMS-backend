using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.States;
using Data.Citys;


namespace Data.Citys
{
    public interface ICityService
    {
        List<CityResponseModel> GetCitys();
        City GetCity(int Id);
        void CreateCity(City CityObj);
        void UpdateCity(City CityObj);
        bool DeleteCity(int Id);
        List<SelectListItem> GetCityDropdown();

    }
    public class CityService : ICityService
    {

        private readonly IStateRepository _stateRepository = new StateRepository(new DbFactory());
        private readonly ICityRepository _cityRepository = new CityRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());

        public List<CityResponseModel> GetCitys()
        {
            var CityList = (
                                       from _city in _cityRepository.GetAll()
                                       join _state in _stateRepository.GetAll() on _city.StateId equals _state.Id

                                       select new CityResponseModel
                                       {
                                           Id = _city.Id,
                                           Name = _city.Name,
                                           StateId = _state.Id,
                                           StateName = _state.Name
                                          


                                       }).ToList();
            return CityList;


        }
        public City GetCity(int Id)
        {
            var Result = _cityRepository.GetById(Id);
            return Result;
        }
        public void CreateCity(City CityObj)
        {
            _cityRepository.Add(CityObj);
        }
        public void UpdateCity(City CityObj)
        {
            _cityRepository.Update(CityObj);
        }

        public bool DeleteCity(int Id)
        {
            var Result = _cityRepository.GetById(Id);
            _cityRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetCityDropdown()
        {
            var Result = _cityRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()

            }).ToList();
            return Result;
        }

    }
}



