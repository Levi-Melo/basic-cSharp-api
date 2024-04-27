using basic_api.Data.Repositories;
using basic_api.Domain.Base.Controller;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.Controller
{
    public interface IOrderController
    {
        Task<IEnumerable<StockModel>> AccessOrderStooks(Guid user, Guid order);

        Task<OrderModel> Devolve(Guid order, IEnumerable<StockModel> stocks);

        new Task<OrderModel> Insert(Guid userId, IEnumerable<OrderParams> books);

        Task<OrderModel> Reply(bool accept, Guid order);

        abstract OrderModel Get(OrderModel input);

        abstract IEnumerable<OrderModel> Get(GetManyParams<OrderModel> input);

        abstract OrderModel Update(OrderModel entity);

        abstract IEnumerable<OrderModel> Update(IEnumerable<OrderModel> input);

        abstract void Delete(OrderModel entity);

        abstract void Delete(IEnumerable<OrderModel> input);
    }
}
