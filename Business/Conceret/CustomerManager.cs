using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conceret
{
    public class CustomerManager : ICustomerRepository
    {
        private ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IResult Add(Customer entity)
        {
            bool result = _customerRepository.Add(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IResult Delete(int id)
        {
            bool result = _customerRepository.Delete(id);
            if (result = true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IDataResult<Customer >Get(int id)
        {
            var result = _customerRepository.Get(id);
            if (result == null)
                return new ErrorDataResult<Customer>();
            return new SuccessDataResult<Customer>(result);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerRepository.GetAll();
            if (result.Count == 0)
                return new ErrorDataResult<List<Customer>>();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IResult Update(Customer entity)
        {
            bool result = _customerRepository.Update(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
