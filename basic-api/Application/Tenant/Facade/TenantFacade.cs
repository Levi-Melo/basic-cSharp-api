using basic_api.Data.Entities;
using basic_api.Data.Repositories;
using basic_api.Domain.Tenant.Facade;
using basic_api.Domain.Tenant.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;

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

        public void Delete(TenantGetModel entity)
        {
            _deleteUseCase.Execute(entity);
        }

        public void Delete(IEnumerable<TenantGetModel> input)
        {
            _deleteUseCase.Execute(input);
        }

        public TenantModel Get(TenantGetModel input)
        {
            return _getUseCase.Execute(input);
        }

        public IEnumerable<TenantModel> Get(GetManyParams<TenantGetModel> input)
        {
            return _getUseCase.Execute(input);
        }

        public TenantModel Insert(TenantModel entity)
        {
            return _insertUseCase.Execute(entity);
        }

        public IEnumerable<TenantModel> Insert(IEnumerable<TenantModel> entity)
        {
            return _insertUseCase.Execute(entity);
        }

        public TenantModel Update(TenantUpdateModel entity)
        {
            return _updateUseCase.Execute(entity);
        }

        public IEnumerable<TenantModel> Update(IEnumerable<TenantUpdateModel> input)
        {
            return _updateUseCase.Execute(input);
        }
    }
}
