using basic_api.Data.Repositories;
using basic_api.Domain.Tenant.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Application.Tenant.UseCases
{
    public class TenantUpdateUseCase(ITenantRepository repo) : ITenantUpdateUseCase
    {
        private readonly ITenantRepository _repository = repo;

        public TenantModel Execute(TenantUpdateModel input)
        {
            return _repository.Update(input);
        }

        public IEnumerable<TenantModel> Execute(IEnumerable<TenantUpdateModel> input)
        {
            return _repository.Update(input);
        }
    }
}
