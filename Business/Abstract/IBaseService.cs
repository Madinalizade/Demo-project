using Core.Entities.Abstract;
using Core.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBaseService<T> where T: class,IEntity,new()
    {
        IResult Add( T entity);
        IResult Update(T entity);
        IResult Delete(int id);
        IDataResult<List<T>> GetAll();
        IDataResult<T> Get(int id);
    }
}
