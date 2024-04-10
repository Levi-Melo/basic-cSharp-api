using basic_api.Data.Entities;
using basic_api.Data.Entities.Base;
using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Base.UseCase
{
    public class TenantDeleteUseCase(TenantenantRepository repo) : ITenantDeleteUseCase
    {

        private readonly TenantenantRepository _repository = repo;

        public void Execute(ITenant entity)
        {
            _repository.Delete(entity);
        }

        public void Execute(IEnumerable<ITenant> input)
        {
            _repository.Delete(input);
        }
    }
}
