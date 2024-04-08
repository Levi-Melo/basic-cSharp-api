using basic_api.Application.Base.UseCase;
using basic_api.Domain.Base.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Base
{
    public abstract class Facade<T>(
        GetUseCase<T> getUseCase,
        DeleteUseCase<T> deleteUseCase,
        InsertUseCase<T> insertUseCase,
        UpdateUseCase<T> updateUseCase
        ) : IFacade<T>
    where T : BaseEntity
{
        readonly GetUseCase<T> _getUseCase = getUseCase;
        readonly DeleteUseCase<T> _deleteUseCase = deleteUseCase;
        readonly InsertUseCase<T> _insertUseCase = insertUseCase;
        readonly UpdateUseCase<T> _updateUseCase = updateUseCase;

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

        public IEnumerable<T> Get(IEnumerable<T> input)
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
