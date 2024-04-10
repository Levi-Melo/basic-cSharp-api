using basic_api.Application.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Domain.Order.UseCases
{
    public class DevolveOrderUseCase(OrderRepository repo, StockUpdateUseCase updateStock) : IDevolveOrderUseCase
    {
        private readonly StockUpdateUseCase _updateStock = updateStock;
        private readonly OrderRepository _repo = repo;
        public async Task<OrderModel> Execute(Guid order, IEnumerable<StockModel> stocks)
        {
            var orderParams = new OrderModel()
            {
                Id = order,
                Deleted = false
            };
            var foundOrder = _repo.Get(orderParams);
            foreach (var stock in stocks) 
            {
                if(foundOrder.StockBooks.Any(item => item.Id == stock.Id))
                {
                    foundOrder.Devolved = false;
                }
                else
                {
                    stock.Reserved = false;
                    await _updateStock.Execute(stock);
                }
                foundOrder.Devolved ??= true;
            }
            return _repo.Update(foundOrder);
        }
    }
}
