using basic_api.Domain.Entities;

namespace basic_api.Domain.Base.UseCases
{
    public interface IUpdateUseCase<T, G>
    where T: IBaseEntity
    where G : T 
    {
        T Execute(G entity);

        IEnumerable<T> Execute(IEnumerable<G> input);
    }
}
