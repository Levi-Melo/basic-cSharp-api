using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Domain.Entities;

namespace basic_api.Application.Base
{
    public class DeleteUseCase<T, G>(IBaseRepository<T, G> repo) : IDeleteUseCase<G>
    where T : IBaseEntity
    where G : T
    {

        private IBaseRepository<T, G> _repository = repo;

        public void Execute(G entity)
        {
            _repository.Delete(entity);
        }

        public void Execute(IEnumerable<G> input)
        {
            _repository.Delete(input);
        }
    }
}
