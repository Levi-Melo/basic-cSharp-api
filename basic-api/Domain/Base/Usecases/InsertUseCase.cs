using basic_api.Domain.Entities;

namespace basic_api.Domain.Base.UseCases
{
    public interface IInsertUseCase<T>
    where T: IBaseEntity
    {
        T Execute(T input);

        IEnumerable<T> Execute(IEnumerable<T> input);
    }
}
