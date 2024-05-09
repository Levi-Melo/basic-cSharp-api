using basic_api.Data.Entities;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Domain.Tenant.UseCases
{
    public interface ITenantUpdateUseCase
    {
        TenantModel Execute(TenantUpdateModel entity);

        IEnumerable<TenantModel> Execute(IEnumerable<TenantUpdateModel> input);
    }
}
