using Core.Entity.Abstract;
using Core.Helper.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<T> where T : class, IEntity,new()
    {
        IResult Add(T entity);
        IResult Delete(int id);
        IResult Update(T entity);
        IDataResult<T> Get(int id);
        IDataResult<List<T>> GetAll();
    }
}
