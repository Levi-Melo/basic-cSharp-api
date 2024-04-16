using basic_api.Data.Entities;
using basic_api.Data.Repositories;

namespace basic_api.Domain.Tenant.UseCases
{
    public interface ITenantGetUseCase
    {
        ITenant Execute(ITenant entity);

        IEnumerable<ITenant> Execute(GetManyParams<ITenant> input);
    }
}
