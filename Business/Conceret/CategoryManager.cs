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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IResult Add(Category entity)
        {
            bool result = _categoryRepository.Add(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IResult Delete(int id)
        {
            bool result = _categoryRepository.Delete(id);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IDataResult<Category> Get(int id)
        {
            var result = _categoryRepository.Get(id);
            if (result == null)
                return new ErrorDataResult<Category>();
            return new SuccessDataResult<Category>(result);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryRepository.GetAll();
            if (result.Count == 0)
                return new ErrorDataResult<List<Category>>();
            return new SuccessDataResult<List<Category>>(result);
        }

        public IResult Update(Category entity)
        {
            bool result = _categoryRepository1.Update(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

    }
}
