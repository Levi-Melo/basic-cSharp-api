using basic_api.Data.Entities.Base;

namespace basic_api.Domain.Base.Facade
{
    public interface IFacade<T, G>
    where T : IBaseEntity 
    where G : T
    {
        T Get(G input);

        IEnumerable<T> Get(IEnumerable<G> input);
        
        T Insert(T entity);
        
        IEnumerable<T> Insert(IEnumerable<T> entity);

        T Update(G entity);

        IEnumerable<T> Update(IEnumerable<G> input);

        void Delete(G entity);

        void Delete(IEnumerable<G> input);
    }
}
