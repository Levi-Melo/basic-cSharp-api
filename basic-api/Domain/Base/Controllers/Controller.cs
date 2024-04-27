using basic_api.Data.Entities.Base;
using basic_api.Data.Repositories;

namespace basic_api.Domain.Base.Controller
{
    public interface IController<T>
    where T : IBaseEntity 
    {
        abstract T Get(T input);

        abstract IEnumerable<T> Get(GetManyParams<T> input);

        abstract T Insert(T entity);

        abstract IEnumerable<T> Insert(IEnumerable<T> entity);

        abstract T Update(T entity);

        abstract IEnumerable<T> Update(IEnumerable<T> input);

        abstract void Delete(T entity);

        abstract void Delete(IEnumerable<T> input);
    }
}
