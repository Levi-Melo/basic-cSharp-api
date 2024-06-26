using basic_api.Data.Entities.Base;
using basic_api.Data.Repositories;

namespace basic_api.Domain.Base.Facade
{
    public interface IFacade<T>
    where T : IBaseEntity 
    {
        T Get(T input);

        IEnumerable<T> Get(GetManyParams<T> input);
        
        T Insert(T entity);
        
        IEnumerable<T> Insert(IEnumerable<T> entity);

        T Update(T entity);

        IEnumerable<T> Update(IEnumerable<T> input);

        void Delete(T entity);

        void Delete(IEnumerable<T> input);
    }
}
