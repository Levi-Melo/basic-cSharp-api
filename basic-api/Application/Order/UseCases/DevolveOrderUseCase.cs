using basic_api.Data.Repositories;
using basic_api.Domain.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.UseCases
{
    public class DevolveOrderUseCase(IOrderRepository repo, IStockUpdateUseCase updateStock) : IDevolveOrderUseCase
    {
        private readonly IStockUpdateUseCase _updateStock = updateStock;
        private readonly IOrderRepository _repo = repo;
        public async Task<OrderModel> Execute(Guid order, IEnumerable<StockModel> stocks)
        {
            _repo.BeginTransaction();
            var orderParams = new OrderModel()
            {
                Id = order,
                Deleted = false
            };
            var foundOrder = _repo.Get(orderParams);
            foreach (var stock in foundOrder.StockBooks) 
            {
                if(!stocks.Any(item => item.Id == stock.Id))
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
            var result = _repo.Update(foundOrder);
            
            _repo.Commit();
            
            return result;
        }
    }
}
