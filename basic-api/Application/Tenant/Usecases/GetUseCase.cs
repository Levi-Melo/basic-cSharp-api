using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Domain.Tenant.UseCases;

namespace basic_api.Application.Tenant.UseCases
{
    public class TenantGetUseCase(ITenantRepository repo) : ITenantGetUseCase
    {
        private readonly ITenantRepository _repository = repo;

        public ITenant Execute(ITenant input)
        {
           return _repository.Get(input);
        }

        public IEnumerable<ITenant> Execute(IEnumerable<ITenant> input)
        {
           return _repository.Get(input);
        }
    }
}
