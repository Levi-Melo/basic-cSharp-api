using basic_api.Data.Entities.Base;

namespace basic_api.Domain.Base.UseCases
{
    public interface IGetUseCase<T,G>
    where T: IBaseEntity
    where G : T
    {
        T Execute(G input);

        IEnumerable<T> Execute(IEnumerable<G> input);
    }
}
