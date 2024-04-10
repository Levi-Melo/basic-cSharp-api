using basic_api.Application.Base;
using basic_api.Application.Order.UseCases;
using basic_api.Domain.Order.Facade;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Order.Facade
{
    public class OrderFacade(
        OrderGetUseCase getUseCase, 
        OrderDeleteUseCase deleteUseCase, 
        OrderInsertUseCase insertUseCase, 
        OrderUpdateUseCase updateUseCase,
        AccessOrderStooksUseCase accessOrderStooks,
        DevolveOrderUseCase devolveOrder,
        ReplyOrderUseCase replyOrder
            ) : Facade<OrderModel>(
                getUseCase, 
                deleteUseCase, 
                insertUseCase,
                updateUseCase
                ), IOrderFacade
    {

        private readonly OrderInsertUseCase _insertUseCase = insertUseCase;
        private readonly ReplyOrderUseCase _replyOrder = replyOrder;
        private readonly AccessOrderStooksUseCase _accessOrderStooks = accessOrderStooks;
        private readonly DevolveOrderUseCase _devolveOrder = devolveOrder;

        public async Task<IEnumerable<StockModel>> AccessOrderStooks(Guid user, Guid order)
        {
            return await _accessOrderStooks.Execute(user, order);
        }

        public async Task<OrderModel> Devolve(Guid order, IEnumerable<StockModel> stocks)
        {
            return await _devolveOrder.Execute(order, stocks);
        }

        public OrderModel Insert(Guid userId, IEnumerable<OrderParams> books)
        {
            return _insertUseCase.Execute(userId, books);
        }

        public async Task<OrderModel> Reply(bool accept, Guid order)
        {
            return await _replyOrder.Execute(accept, order);
        }
    }
}
