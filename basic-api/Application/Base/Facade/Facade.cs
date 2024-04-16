using basic_api.Domain.Base.UseCases;
using basic_api.Domain.Base.Facade;
using basic_api.Infrastructure.Database.Models;
using basic_api.Data.Repositories;

namespace basic_api.Application.Base
{
    public abstract class Facade<T>(
        IGetUseCase<T> getUseCase,
        IDeleteUseCase<T> deleteUseCase,
        IInsertUseCase<T> insertUseCase,
        IUpdateUseCase<T> updateUseCase
        ) : IFacade<T>
    where T : BaseEntity
{
        readonly IGetUseCase<T> _getUseCase = getUseCase;
        readonly IDeleteUseCase<T> _deleteUseCase = deleteUseCase;
        readonly IInsertUseCase<T> _insertUseCase = insertUseCase;
        readonly IUpdateUseCase<T> _updateUseCase = updateUseCase;

        public void Delete(T entity)
        {
            _deleteUseCase.Execute(entity);
        }

        public void Delete(IEnumerable<T> input)
        {
            _deleteUseCase.Execute(input);
        }

        public T Get(T input)
        {
            return _getUseCase.Execute(input);
        }

        public IEnumerable<T> Get(GetManyParams<T> input)
        {
            return _getUseCase.Execute(input);
        }

        public T Insert(T entity)
        {
            return _insertUseCase.Execute(entity);
        }

        public IEnumerable<T> Insert(IEnumerable<T> entity)
        {
            return _insertUseCase.Execute(entity);
        }

        public T Update(T entity)
        {
            return _updateUseCase.Execute(entity);
        }

        public IEnumerable<T> Update(IEnumerable<T> input)
        {
            return _updateUseCase.Execute(input);
        }
    }
}
