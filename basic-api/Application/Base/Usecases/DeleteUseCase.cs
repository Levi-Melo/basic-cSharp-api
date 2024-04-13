using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Base.UseCase
{
    public abstract class DeleteUseCase<T>(IBaseRepository<T> repo) : IDeleteUseCase<T>
    where T : BaseEntity
    {

        private readonly IBaseRepository<T> _repository = repo;

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
