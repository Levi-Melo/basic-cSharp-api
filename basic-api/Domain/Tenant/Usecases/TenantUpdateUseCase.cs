using basic_api.Data.Entities;

namespace basic_api.Domain.Base.UseCases
{
    public interface ITenantUpdateUseCase
    {
        ITenant Execute(ITenant entity);

        IEnumerable<ITenant> Execute(IEnumerable<ITenant> input);
    }
}
