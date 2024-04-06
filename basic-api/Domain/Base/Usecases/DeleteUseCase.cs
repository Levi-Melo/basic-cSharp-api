using basic_api.Domain.Entities;

namespace basic_api.Domain.Base.UseCases
{
    public interface IDeleteUseCase<T>
    where T : IBaseEntity 
    {
        void Execute(T entity);

        void Execute(IEnumerable<T> input);
    }
}
