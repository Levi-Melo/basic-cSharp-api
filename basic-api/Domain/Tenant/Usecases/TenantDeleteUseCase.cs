using basic_api.Data.Entities;

namespace basic_api.Domain.Base.UseCases
{
    public interface ITenantDeleteUseCase
    {
        void Execute(ITenant entity);

        void Execute(IEnumerable<ITenant> input);
    }
}
