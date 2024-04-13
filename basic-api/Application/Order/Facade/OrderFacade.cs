using basic_api.Application.Base;
using basic_api.Domain.Order.Facade;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Order.Facade
{
    
    public class OrderFacade(
        IOrderGetUseCase getUseCase, 
        IOrderDeleteUseCase deleteUseCase, 
        IOrderInsertUseCase insertUseCase, 
        IOrderUpdateUseCase updateUseCase,
        IAccessOrderStooksUseCase accessOrderStooks,
        IDevolveOrderUseCase devolveOrder,
        IReplyOrderUseCase replyOrder,
        IVerifyStatusOrderUsecase verifyOrdersStatus
            ) : Facade<OrderModel>(
                getUseCase, 
                deleteUseCase, 
                insertUseCase,
                updateUseCase
                ), IOrderFacade
    {

        private readonly IVerifyStatusOrderUsecase _verifyOrdersStatus = verifyOrdersStatus;
        private readonly IOrderInsertUseCase _insertUseCase = insertUseCase;
        private readonly IReplyOrderUseCase _replyOrder = replyOrder;
        private readonly IAccessOrderStooksUseCase _accessOrderStooks = accessOrderStooks;
        private readonly IDevolveOrderUseCase _devolveOrder = devolveOrder;

        public async Task<IEnumerable<StockModel>> AccessOrderStooks(Guid user, Guid order)
        {
            return await _accessOrderStooks.Execute(user, order);
        }

        public async Task<OrderModel> Devolve(Guid order, IEnumerable<StockModel> stocks)
        {
            return await _devolveOrder.Execute(order, stocks);
        }

        public async Task<OrderModel> Insert(Guid userId, IEnumerable<OrderParams> books)
        {
            return await _insertUseCase.ExecuteAsync(userId, books);
        }

        public async Task<OrderModel> Reply(bool accept, Guid order)
        {
            return await _replyOrder.Execute(accept, order);
        }

        public async Task VerifyOrdersStatus()
        {
            await _verifyOrdersStatus.Execute();
        }
    }
}
