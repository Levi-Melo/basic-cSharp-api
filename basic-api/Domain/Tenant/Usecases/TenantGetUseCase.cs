using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Domain.Tenant.UseCases
{
    public interface ITenantGetUseCase
    {
        TenantModel Execute(TenantGetModel entity);

        IEnumerable<TenantModel> Execute(GetManyParams<TenantGetModel> input);
    }
}
