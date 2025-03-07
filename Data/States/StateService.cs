using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Citys;
using Data.States;


namespace Data.States
{
    public interface IStateService
    {
        List<StateResponseModel> GetStates();
        State GetState(int Id);
        void CreateState(State StateObj);
        void UpdateState(State StateObj);
        bool DeleteState(int Id);
        List<SelectListItem> GetStateDropdown();

    }
    public class StateService : IStateService
    {

        private readonly ICityRepository _cityRepository = new CityRepository(new DbFactory());
        private readonly IStateRepository _stateRepository = new StateRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());

        public List<StateResponseModel> GetStates()
        {
            var StateList = (
                                       from _state in _stateRepository.GetAll()
                                       join _city in _cityRepository.GetAll() on _state.CountryId equals _city.Id

                                       select new StateResponseModel
                                       {
                                           Id = _state.Id,
                                           Name = _state.Name,
                                           CountryId = _city.Id,
                                           CityName = _city.Name,
                                          


                                       }).ToList();
            return StateList;


        }
        public State GetState(int Id)
        {
            var Result = _stateRepository.GetById(Id);
            return Result;
        }
        public void CreateState(State StateObj)
        {
            _stateRepository.Add(StateObj);
        }
        public void UpdateState(State StateObj)
        {
            _stateRepository.Update(StateObj);
        }

        public bool DeleteState(int Id)
        {
            var Result = _stateRepository.GetById(Id);
            _stateRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetStateDropdown()
        {
            var Result = _stateRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()

            }).ToList();
            return Result;
        }

    }
}



