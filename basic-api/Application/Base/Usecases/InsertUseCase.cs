using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Domain.Entities;

namespace basic_api.Application.Base
{
    public abstract class InsertUseCase<T, G>(IBaseRepository<T, G> repo) : IInsertUseCase<T>
    where T : IBaseEntity
    where G : T
    {
        private IBaseRepository<T,G> _repository = repo;

        public T Execute(T input)
        {
            return _repository.Insert(input);
        }

        public IEnumerable<T> Execute(IEnumerable<T> input)
        {
            return _repository.Insert(input);
        }
    }
}
