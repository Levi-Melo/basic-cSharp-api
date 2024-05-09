using basic_api.Data.Repositories;
using basic_api.Domain.Tenant.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Application.Tenant.UseCases
{
    public class TenantGetUseCase(ITenantRepository repo) : ITenantGetUseCase
    {
        private readonly ITenantRepository _repository = repo;

        public TenantModel Execute(TenantGetModel input)
        {
           return _repository.Get(input);
        }

        public IEnumerable<TenantModel> Execute(GetManyParams<TenantGetModel> input)
        {
           return _repository.Get(input);
        }
    }
}
