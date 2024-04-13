using basic_api.Data.Repositories;
using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Base.UseCase
{
    public abstract class InsertUseCase<T>(IBaseRepository<T> repo) : IInsertUseCase<T>
    where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository = repo;

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
