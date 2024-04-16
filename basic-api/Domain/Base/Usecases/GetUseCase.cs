using basic_api.Data.Entities.Base;
using basic_api.Data.Repositories;

namespace basic_api.Domain.Base.UseCases
{
    public interface IGetUseCase<T>
    where T: IBaseEntity
    {
        T Execute(T input);

        IEnumerable<T> Execute(GetManyParams<T> input);
    }
}
