using basic_api.Domain.Base.Controller;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.Controller
{
    public interface IOrderController : IController<OrderModel>
    {
        Task<IEnumerable<StockModel>> AccessOrderStooks(Guid user, Guid order);

        Task<OrderModel> Devolve(Guid order, IEnumerable<StockModel> stocks);

        Task<OrderModel> Insert(Guid userId, IEnumerable<OrderParams> books);

        Task<OrderModel> Reply(bool accept, Guid order);
    }
}
