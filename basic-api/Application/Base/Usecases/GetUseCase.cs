using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Base.UseCase
{
    public abstract class GetUseCase<T, G>(BaseRepository<T, G> repo) : IGetUseCase<T, G>
    where T : BaseEntity
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
