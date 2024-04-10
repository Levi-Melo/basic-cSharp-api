using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Base.UseCase
{
    public class TenantGetUseCase(TenantenantRepository repo) : ITenantGetUseCase
    {
        private readonly TenantenantRepository _repository = repo;

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
