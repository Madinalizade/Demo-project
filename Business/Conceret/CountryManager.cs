using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conceret
{
    public class CountryManager : ICountryRepository
    {
        private readonly ICountryRepository _countryRepository;
        public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public IResult  Add(Country entity)
        {
            bool result = _countryRepository.Add(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();

        }

        public IResult Delete(int id)
        {
            bool result = _countryRepository.Delete(id);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IDataResult<Country> Get(int id)
        {
            var result = _countryRepository.Get(id);
            if (result == null)
                return new ErrorDataResult<Country>();
            return new SuccessDataResult<Country>(result);
        }

        public IDataResult<List<Country>> GetAll()
        {
            var result = _countryRepository.GetAll();
            if (result.Count == 0)
                return new ErrorDataResult<List<Country>>();
            return new SuccessDataResult<List<Country>>(result);
        }

        public IResult Update(Country entity)
        {
            bool result = _countryRepository.Update(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
