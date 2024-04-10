using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.UseCases
{
    public interface IReplyOrderUseCase
    {
        OrderModel Execute(bool accept, Guid order);
    }
}
