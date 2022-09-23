using Business.Abstract;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conceret
{
    public class CityManager : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public IResult Add(City entity)
        {
            bool result = _cityRepository.Add(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IResult Delete(int id)
        {
            bool result = _cityRepository.Delete(id);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();

        }

        public IDataResult<City> Get(int id)
        {
            var result = _cityRepository.Get(id);
            if (result == null)
                return new ErrorDataResult<City>();
            return new SuccessDataResult<City>(result);
        }

        public IDataResult<List<City>> GetAll()
        {
            var result = _cityRepository.GetAll();
            if (result.Count == 0)
                return new ErrorDataResult<List<City>>();
            return new SuccessDataResult<List<City>>(result);
        }

        public IResult Update(City entity)
        {bool result = _cityRepository.Update(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
