using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conceret
{
    public class OrderManager: IOrderRepository
    {
        private IOrderRepository _orderRepository;
        public OrderManager (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IResult Add(Order entity)
        {
            bool result = _orderRepository.Add(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();

        }

        public IResult Delete(int id)
        {
            bool result = _orderRepository.Delete(id);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IDataResult<Order> Get(int id)
        {
            var result = _orderRepository.Get(id);
            if (result == null)
                return new ErrorDataResult<Order>();
            return new SuccessDataResult<Order>(result);
        }

        public IDataResult<List<Order>> GetAll()
        {
            var result = _orderRepository.GetAll();
            if (result.Count == 0)
                return new ErrorDataResult<List<Order>>();
            return new SuccessDataResult<List<Order>>(result);
        }

        public IResult Update(Order entity)
        {
            bool result = _orderRepository.Update(entity);
            if (result == true)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
