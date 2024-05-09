using basic_api.Data.Entities;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Tenant.UseCases
{
    public interface ITenantInsertUseCase
    {
        TenantModel Execute(TenantModel entity);

        IEnumerable<TenantModel> Execute(IEnumerable<TenantModel> input);
    }
}
