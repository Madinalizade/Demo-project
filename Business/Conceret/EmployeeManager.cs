using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conceret
{
    public class EmployeeManager : IEmployeeRepository
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IResult Add(Employee entity)
        {
            bool result = _employeeRepository.Add(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IResult Delete(int id)
        {
            bool result = _employeeRepository.Delete(id);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IDataResult<Employee >Get(int id)
        {
            var result = _employeeRepository.Get(id);
            if (result == null)
                return new ErrorDataResult<Employee>();
            return new SuccessDataResult<Employee>(result);
        }

        public IDataResult<List<Employee>> GetAll()
        {
            var result = _employeeRepository.GetAll();
            if (result.Count == 0)
                return new ErrorDataResult<List<Employee>>();
            return new SuccessDataResult<List<Employee>>(result);
        }

        public IResult Update(Employee entity)
        {
            bool result = _employeeRepository.Update(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
