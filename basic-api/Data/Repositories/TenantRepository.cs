using basic_api.Data.Entities;

namespace basic_api.Data.Repositories
{
    public interface ITenantRepository : IDisposable
    {
        ITenant Get(ITenant input);

        IEnumerable<ITenant> Get(GetManyParams<ITenant> input);

        ITenant Insert(ITenant entity);

        IEnumerable<ITenant> Insert(IEnumerable<ITenant> entity);

        ITenant Update(ITenant entity);

        IEnumerable<ITenant> Update(IEnumerable<ITenant> input);

        void Delete(ITenant entity);

        void Delete(GetManyParams<ITenant> input);
    }
}
