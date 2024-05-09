using basic_api.Data.Repositories;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Domain.Order.Controller
{
    public interface IOrderController
    {
        Task<IEnumerable<StockModel>> AccessOrderStooks(Guid user, Guid order);

        Task<OrderModel> Devolve(Guid order, IEnumerable<StockModel> stocks);

        new Task<OrderModel> Insert(Guid userId, IEnumerable<OrderParams> books);

        Task<OrderModel> Reply(bool accept, Guid order);

        abstract OrderModel Get(OrderGetModel input);

        abstract IEnumerable<OrderModel> Get(GetManyParams<OrderGetModel> input);

        abstract OrderModel Update(OrderUpdateModel entity);

        abstract IEnumerable<OrderModel> Update(IEnumerable<OrderUpdateModel> input);

        abstract void Delete(OrderGetModel entity);

        abstract void Delete(IEnumerable<OrderGetModel> input);
    }
}
