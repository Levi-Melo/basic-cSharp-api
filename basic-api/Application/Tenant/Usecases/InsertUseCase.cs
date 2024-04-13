using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Domain.Tenant.UseCases;

namespace basic_api.Application.Tenant.UseCases
{
    public class TenantInsertUseCase(ITenantRepository repo) : ITenantInsertUseCase
    {
        private readonly ITenantRepository _repository = repo;

        public ITenant Execute(ITenant input)
        {
            return _repository.Insert(input);
        }

        public IEnumerable<ITenant> Execute(IEnumerable<ITenant> input)
        {
            return _repository.Insert(input);
        }
    }
}
