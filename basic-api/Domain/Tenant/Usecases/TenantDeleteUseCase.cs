using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Domain.Tenant.UseCases
{
    public interface ITenantDeleteUseCase
    {
        void Execute(TenantGetModel entity);

        void Execute(IEnumerable<TenantGetModel> input);
    }
}
