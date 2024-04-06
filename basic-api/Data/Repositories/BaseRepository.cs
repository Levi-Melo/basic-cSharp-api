using basic_api.Domain.Entities;

namespace basic_api.Data.Repositories
{
    public interface IBaseRepository<T, G > : IDisposable 
        where T : IBaseEntity
        where G : T 
    {
        IEnumerable<T> Find(IEnumerable<G> input);

        T FindOne(T input);

        T Insert(Guid id,G input);

        T Update(T input);

        T Delete(Guid id);
    }

}
