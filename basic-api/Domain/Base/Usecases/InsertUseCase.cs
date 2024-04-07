using basic_api.Data.Entities.Base;

namespace basic_api.Domain.Base.UseCases
{
    public interface IInsertUseCase<T>
    where T: IBaseEntity
    {
        T Execute(T input);

        IEnumerable<T> Execute(IEnumerable<T> input);
    }
}
