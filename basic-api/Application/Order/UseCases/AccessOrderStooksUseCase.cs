using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Order.UseCases;
using basic_api.Data.Repositories;
using basic_api.Domain.Stock.UseCases;

namespace basic_api.Application.Order.UseCases
{
    public class AccessOrderStooksUseCase(IOrderRepository repo, IStockGetUseCase getStock ) : IAccessOrderStooksUseCase
    {
        private readonly IOrderRepository _repo = repo;
        private readonly IStockGetUseCase _getStock = getStock;
        public async Task<IEnumerable<StockModel>> Execute(Guid user, Guid order)
        {
            var userParams = new AccountModel()
            {
                Id = user,
                Deleted = false
            };

            var orderParams = new OrderModel()
            {
                Id= order,
                OrderAuthor = userParams,
                Accept = true,
                Deleted = false,
                Devolved = null
            };

            var foundOrder = _repo.Get(orderParams);

            if(foundOrder.DevolveAt == null)
            {
                foundOrder.DevolveAt = DateTime.Now.AddDays(30);

                _repo.Update(foundOrder);

            }
            else
            {
                var isBefore = DateTime.Compare((DateTime)foundOrder.DevolveAt, DateTime.Now);
                if(isBefore < 0) {
                    throw new Exception();
                }
            }

            return await _getStock.Execute(foundOrder.StockBooks);
        }
    }
}
