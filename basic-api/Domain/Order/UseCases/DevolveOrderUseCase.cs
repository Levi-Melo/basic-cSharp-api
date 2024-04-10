using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.UseCases
{
    public interface IDevolveOrderUseCase
    {
        Task<OrderModel> Execute(Guid order, IEnumerable<StockModel> stocks);
    }
}
