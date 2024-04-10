using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.UseCases
{
    public interface IReplyOrderUseCase
    {
        Task<OrderModel> Execute(bool accept, Guid order);
    }
}
