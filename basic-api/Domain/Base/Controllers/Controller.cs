using basic_api.Data.Entities.Base;

namespace basic_api.Domain.Base.Controller
{
    public interface IController<T>
    where T : IBaseEntity 
    {
        T Get(T input);

        IEnumerable<T> Get(IEnumerable<T> input);
        
        T Insert(T entity);
        
        IEnumerable<T> Insert(IEnumerable<T> entity);

        T Update(T entity);

        IEnumerable<T> Update(IEnumerable<T> input);

        void Delete(T entity);

        void Delete(IEnumerable<T> input);
    }
}
