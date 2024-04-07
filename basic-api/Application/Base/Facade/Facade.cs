using basic_api.Data.Entities.Base;
using basic_api.Data.Repositories;
using basic_api.Domain.Base.Facade;
using basic_api.Domain.Base.UseCases;

namespace basic_api.Application.Base
{
    public abstract class Facade<T, G>(
        IGetUseCase<T, G> getUseCase,
        IDeleteUseCase<G> deleteUseCase,
        IInsertUseCase<T> insertUseCase,
        IUpdateUseCase<T, G> updateUseCase
        ) : IFacade<T, G>
    where T : IBaseEntity
    where G : T
{
    IGetUseCase<T,G> _getUseCase = getUseCase;
    IDeleteUseCase<G> _deleteUseCase = deleteUseCase;
    IInsertUseCase<T> _insertUseCase = insertUseCase;
    IUpdateUseCase<T,G> _updateUseCase = updateUseCase;

        public void Delete(G entity)
        {
            _deleteUseCase.Execute(entity);
        }

        public void Delete(IEnumerable<G> input)
        {
            _deleteUseCase.Execute(input);
        }

        public T Get(G input)
        {
            return _getUseCase.Execute(input);
        }

        public IEnumerable<T> Get(IEnumerable<G> input)
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

        public T Update(G entity)
        {
            return _updateUseCase.Execute(entity);
        }

        public IEnumerable<T> Update(IEnumerable<G> input)
        {
            return _updateUseCase.Execute(input);
        }
    }
}
