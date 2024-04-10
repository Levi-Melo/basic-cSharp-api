using basic_api.Data.Entities.Base;
using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Base.UseCase
{
    public abstract class DeleteUseCase<T>(BaseRepository<T> repo) : IDeleteUseCase<T>
    where T : BaseEntity
    {

        private readonly BaseRepository<T> _repository = repo;

        public void Execute(T entity)
        {
            _repository.Delete(entity);
        }

        public void Execute(IEnumerable<T> input)
        {
            _repository.Delete(input);
        }
    }
}
