using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Base.UseCase
{
    public abstract class UpdateUseCase<T>(IBaseRepository<T> repo) : IUpdateUseCase<T>
    where T: BaseEntity
    {
        private readonly IBaseRepository<T> _repository = repo;

        public T Execute(T entity){
            return _repository.Update(entity);
        }

        public  IEnumerable<T> Execute(IEnumerable<T> input){
            return _repository.Update(input);
        }
    }
}
