using basic_api.Data.Entities.Base;
using basic_api.Data.Repositories;

namespace basic_api.Domain.Base.Controller
{
    public interface IController<T, G, H>
    where T : IBaseEntity 
    where G : T
    where H : G
    {
        abstract T Get(G input);

        abstract IEnumerable<T> Get(GetManyParams<G> input);

        abstract T Insert(T entity);

        abstract IEnumerable<T> Insert(IEnumerable<T> entity);

        abstract T Update(H entity);

        abstract IEnumerable<T> Update(IEnumerable<H> input);

        abstract void Delete(G entity);

        abstract void Delete(IEnumerable<G> input);
    }
}
