using basic_api.Data.Entities;
using basic_api.Data.Repositories;

namespace basic_api.Domain.Tenant.Controller
{
    public interface ITenantController
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
