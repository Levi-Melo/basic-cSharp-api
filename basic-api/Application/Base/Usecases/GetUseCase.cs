using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Domain.Entities;

namespace basic_api.Application.Base
{
    public abstract class GetUseCase<T, G>(IBaseRepository<T, G> repo) : IGetUseCase<T, G>
    where T : IBaseEntity
    where G : T
    {
        private IBaseRepository<T,G> _repository = repo;

        public T Execute(G input)
        {
           return _repository.Get(input);
        }

        public IEnumerable<T> Execute(IEnumerable<G> input)
        {
           return _repository.Get(input);
        }
    }
}
