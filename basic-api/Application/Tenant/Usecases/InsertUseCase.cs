using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Domain.Tenant.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Application.Tenant.UseCases
{
    public class TenantInsertUseCase(ITenantRepository repo) : ITenantInsertUseCase
    {
        private readonly ITenantRepository _repository = repo;

        public TenantModel Execute(TenantModel input)
        {
            return _repository.Insert(input);
        }

        public IEnumerable<TenantModel> Execute(IEnumerable<TenantModel> input)
        {
            return _repository.Insert(input);
        }
    }
}
