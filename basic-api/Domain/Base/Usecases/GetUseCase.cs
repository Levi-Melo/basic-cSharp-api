using basic_api.Domain.Entities;

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
