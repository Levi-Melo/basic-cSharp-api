using basic_api.Data.Entities.Base;

namespace basic_api.Domain.Base.UseCases
{
    public interface IUpdateUseCase<T>
    where T: IBaseEntity
    {
        T Execute(T entity);

        IEnumerable<T> Execute(IEnumerable<T> input);
    }
}
