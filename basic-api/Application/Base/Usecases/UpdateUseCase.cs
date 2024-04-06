using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Domain.Entities;

namespace basic_api.Application.Base
{
    public class UpdateUseCase<T, G>(IBaseRepository<T, G> repo) :IUpdateUseCase<T, G>
    where T: IBaseEntity
    where G : T 
    {
        private IBaseRepository<T, G> _repository = repo;

        public T Execute(G entity){
            return _repository.Update(entity);
        }

        public IEnumerable<T> Execute(IEnumerable<G> input){
            return _repository.Update(input);
        }
    }
}
