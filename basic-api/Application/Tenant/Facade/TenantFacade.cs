using basic_api.Application.Base.UseCase;
using basic_api.Data.Entities;
using basic_api.Domain.Base.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Base
{
    public class TenantFacade(
        TenantGetUseCase getUseCase,
        TenantDeleteUseCase deleteUseCase,
        TenantInsertUseCase insertUseCase,
        TenantUpdateUseCase updateUseCase
        ) : ITenantFacade
{
        readonly TenantGetUseCase _getUseCase = getUseCase;
        readonly TenantDeleteUseCase _deleteUseCase = deleteUseCase;
        readonly TenantInsertUseCase _insertUseCase = insertUseCase;
        readonly TenantUpdateUseCase _updateUseCase = updateUseCase;

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
