 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Countrys;


namespace Data.Countrys
{
     public interface ICountryService
    {
        List<CountryResponseModel> GetCountrys();
        Country GetCountry(int Id);
        void CreateCountry(Country CountryObj);
        void UpdateCountry(Country CountryObj);
        bool DeleteCountry(int Id);
        List<SelectListItem> GetCountryDropdown();
         
    }
    public class CountryService : ICountryService
    {
        
         private readonly ICountryRepository _countryRepository = new CountryRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<CountryResponseModel> GetCountrys()
        {
                var CountryList = (
                                           from _country in _countryRepository.GetAll()

                                          select new CountryResponseModel
                                          {
                                               Id = _country.Id,

Name = _country.Name



                                          }).ToList();
                    return CountryList;
            

        }
        public Country GetCountry(int Id)
        {
            var Result = _countryRepository.GetById(Id);
            return Result;
        }
        public void CreateCountry(Country CountryObj)
        {
            _countryRepository.Add(CountryObj);
        }
        public void UpdateCountry(Country CountryObj)
        {
            _countryRepository.Update(CountryObj);
        }

        public bool DeleteCountry(int Id)
        {
            var Result = _countryRepository.GetById(Id);
            _countryRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetCountryDropdown()
        {
            var Result = _countryRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Name.ToString() 

            }).ToList();
            return Result;
        }
         
    }
}
   


