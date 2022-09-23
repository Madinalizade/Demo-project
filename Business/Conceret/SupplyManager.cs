using Core.Result.Abstract;
using Core.Result.Concrete;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conceret
{
    public class SupplyManager : ISupplyRepository
    {
        private ISupplyRepository _supplyRepository;
        public SupplyManager(ISupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }
        public IResult Add(Supply entity)
        {
            bool result = _supplyRepository.Add(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IResult Delete(int id)
        {
            bool result = _supplyRepository.Delete(id);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IDataResult<Supply> Get(int id)
        {
            var result = _supplyRepository.Get(id);
            if (result == null)
                return new ErrorDataResult<Supply>();
            return new SuccessDataResult<Supply>(result);
        }

        public IDataResult<List<Supply>> GetAll()
        {
            var result = _supplyRepository.GetAll();
            if (result.Count == 0)
                return new ErrorDataResult<List<Supply>>();
            return new SuccessDataResult<List<Supply>>(result);
        }

        public IResult Update(Supply entity)
        {bool result = _supplyRepository.Update(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
