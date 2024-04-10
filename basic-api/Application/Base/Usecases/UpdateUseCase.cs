using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Base.UseCase
{
    public abstract class UpdateUseCase<T>(BaseRepository<T> repo) : IUpdateUseCase<T>
    where T: BaseEntity
    {
        private readonly BaseRepository<T> _repository = repo;

        public T Execute(T entity){
            return _repository.Update(entity);
        }

        public  IEnumerable<T> Execute(IEnumerable<T> input){
            return _repository.Update(input);
        }
    }
}
