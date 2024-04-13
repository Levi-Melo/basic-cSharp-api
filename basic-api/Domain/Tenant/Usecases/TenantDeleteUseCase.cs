using basic_api.Data.Entities;

namespace basic_api.Domain.Tenant.UseCases
{
    public interface ITenantDeleteUseCase
    {
        void Execute(ITenant entity);

        void Execute(IEnumerable<ITenant> input);
    }
}
