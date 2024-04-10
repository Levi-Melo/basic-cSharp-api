using basic_api.Domain.Base.Facade;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.Facade
{
    public interface IOrderFacade: IFacade<OrderModel>  
    {
        Task<IEnumerable<StockModel>> AccessOrderStooks(Guid user, Guid order);

        Task<OrderModel> Devolve(Guid order, IEnumerable<StockModel> stocks);
        
        Task<OrderModel> Insert(Guid userId, IEnumerable<OrderParams> books);
        
        Task<OrderModel> Reply(bool accept, Guid order);
    }
}
