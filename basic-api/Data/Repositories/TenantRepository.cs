using basic_api.Data.Entities;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Data.Repositories
{
    public interface ITenantRepository : IDisposable
    {
        TenantModel Get(TenantGetModel input);

        IEnumerable<TenantModel> Get(GetManyParams<TenantGetModel> input);

        TenantModel Insert(TenantModel entity);

        IEnumerable<TenantModel> Insert(IEnumerable<TenantModel> entity);

        TenantModel Update(TenantUpdateModel entity);

        IEnumerable<TenantModel> Update(IEnumerable<TenantUpdateModel> input);

        void Delete(TenantGetModel entity);

        void Delete(IEnumerable<TenantGetModel> input);
    }
}
