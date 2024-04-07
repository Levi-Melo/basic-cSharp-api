using basic_api.Data.Entities.Base;

namespace basic_api.Domain.Base.UseCases
{
    public interface IDeleteUseCase<T>
    where T : IBaseEntity 
    {
        void Execute(T entity);

        void Execute(IEnumerable<T> input);
    }
}
