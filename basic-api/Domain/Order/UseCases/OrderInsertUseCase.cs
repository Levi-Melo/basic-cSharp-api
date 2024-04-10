using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.UseCases
{
    public interface IOrderInsertUseCase : IInsertUseCase<OrderModel>
    {
        Task<OrderModel> ExecuteAsync(Guid userId, IEnumerable<OrderParams> books);
    }
    public struct OrderParams
    {
        public Guid book;

        public bool isVirtual;
    }
}
