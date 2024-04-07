using basic_api.Data.Entities.Base;

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
