using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Order.UseCases;
using basic_api.Application.Stock.UseCases;

namespace basic_api.Application.Order.UseCases
{
    public class AccessOrderStooksUseCase(OrderRepository repo, StockGetUseCase getStock ) : IAccessOrderStooksUseCase
    {
        private readonly OrderRepository _repo = repo;
        private readonly StockGetUseCase _getStock = getStock;
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
                var isBefor = DateTime.Compare((DateTime)foundOrder.DevolveAt, DateTime.Now);
                if(isBefor < 0) {
                    throw new Exception();
                }
            }

            return await _getStock.Execute(foundOrder.StockBooks);
        }
    }
}
