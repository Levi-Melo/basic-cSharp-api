using basic_api.Data.Entities;
using basic_api.Domain.Tenant.Facade;
using basic_api.Domain.Tenant.UseCases;

namespace basic_api.Application.Tenant.Facade
{
    public class TenantFacade(
        ITenantGetUseCase getUseCase,
        ITenantDeleteUseCase deleteUseCase,
        ITenantInsertUseCase insertUseCase,
        ITenantUpdateUseCase updateUseCase
        ) : ITenantFacade
{
        readonly ITenantGetUseCase _getUseCase = getUseCase;
        readonly ITenantDeleteUseCase _deleteUseCase = deleteUseCase;
        readonly ITenantInsertUseCase _insertUseCase = insertUseCase;
        readonly ITenantUpdateUseCase _updateUseCase = updateUseCase;

        public void Delete(ITenant entity)
        {
            _deleteUseCase.Execute(entity);
        }

        public void Delete(IEnumerable<ITenant> input)
        {
            _deleteUseCase.Execute(input);
        }

        public ITenant Get(ITenant input)
        {
            return _getUseCase.Execute(input);
        }

        public IEnumerable<ITenant> Get(IEnumerable<ITenant> input)
        {
            return _getUseCase.Execute(input);
        }

        public ITenant Insert(ITenant entity)
        {
            return _insertUseCase.Execute(entity);
        }

        public IEnumerable<ITenant> Insert(IEnumerable<ITenant> entity)
        {
            return _insertUseCase.Execute(entity);
        }

        public ITenant Update(ITenant entity)
        {
            return _updateUseCase.Execute(entity);
        }

        public IEnumerable<ITenant> Update(IEnumerable<ITenant> input)
        {
            return _updateUseCase.Execute(input);
        }
    }
}
