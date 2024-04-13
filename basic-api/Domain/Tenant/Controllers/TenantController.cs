using basic_api.Data.Entities;

namespace basic_api.Domain.Tenant.Controller
{
    public interface ITenantController
    {
        ITenant Get(ITenant input);

        IEnumerable<ITenant> Get(IEnumerable<ITenant> input);
        
        ITenant Insert(ITenant entity);
        
        IEnumerable<ITenant> Insert(IEnumerable<ITenant> entity);

        ITenant Update(ITenant entity);

        IEnumerable<ITenant> Update(IEnumerable<ITenant> input);

        void Delete(ITenant entity);

        void Delete(IEnumerable<ITenant> input);
    }
}
