using Core.Utilies.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IService<T>
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int Id);
        IResult Add(T Entity);
        IResult Delete(T Entity);
        IResult Update(T Entity);
    }
}
