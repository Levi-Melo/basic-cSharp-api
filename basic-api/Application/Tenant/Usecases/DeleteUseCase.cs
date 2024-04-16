using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Domain.Tenant.UseCases;

namespace basic_api.Application.Tenant.UseCases
{
    public class TenantDeleteUseCase(ITenantRepository repo) : ITenantDeleteUseCase
    {

        private readonly ITenantRepository _repository = repo;

        public void Execute(ITenant entity)
        {
            _repository.Delete(entity);
        }

        public void Execute(GetManyParams<ITenant> input)
        {
            _repository.Delete(input);
        }
    }
}
