using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conceret
{
    public class ProductManager : IProductRepository
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IResult Add(Product entity)
        {
            bool result = _productRepository.Add(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IResult Delete(int id)
        {
            bool result = _productRepository.Delete(id);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IDataResult<Product> Get(int id)
        {
            var result = _productRepository.Get(id);
            if (result == null)
                return new ErrorDataResult<Product>();
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _productRepository.GetAll();
            if (result.Count == 0)
                return new ErrorDataResult<List<Product>>();
            return new SuccessDataResult<List<Product>>(result);
        }

        public IResult Update(Product entity)
        {
            bool result = _productRepository.Update(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
