using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Domain.Tenant.UseCases;
using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Application.Tenant.UseCases
{
    public class TenantDeleteUseCase(ITenantRepository repo) : ITenantDeleteUseCase
    {

        private readonly ITenantRepository _repository = repo;

        public void Execute(TenantGetModel entity)
        {
            _repository.Delete(entity);
        }

        public void Execute(IEnumerable<TenantGetModel> input)
        {
            _repository.Delete(input);
        }
    }
}
