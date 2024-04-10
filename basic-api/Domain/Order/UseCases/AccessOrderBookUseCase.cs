using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.UseCases
{
    public interface IAccessOrderStooksUseCase
    {
        Task<IEnumerable<StockModel>> Execute(Guid user, Guid order);
    }
}
