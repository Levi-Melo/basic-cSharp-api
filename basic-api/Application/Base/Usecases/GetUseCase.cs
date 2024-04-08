using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Base.UseCase
{
    public abstract class GetUseCase<T>(BaseRepository<T> repo) : IGetUseCase<T>
    where T : BaseEntity
    {
        private BaseRepository<T> _repository = repo;

        public T Execute(T input)
        {
           return _repository.Get(input);
        }

        public IEnumerable<T> Execute(IEnumerable<T> input)
        {
           return _repository.Get(input);
        }
    }
}
