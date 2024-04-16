using basic_api.Data.Entities;
using basic_api.Data.Repositories;

namespace basic_api.Domain.Tenant.UseCases
{
    public interface ITenantDeleteUseCase
    {
        void Execute(ITenant entity);

        void Execute(GetManyParams<ITenant> input);
    }
}
