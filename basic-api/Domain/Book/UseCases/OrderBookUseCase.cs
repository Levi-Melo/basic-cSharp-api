using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Book.UseCases
{
    public interface IOrderInsertUseCase
    {
        OrderModel Execute(Guid userId, IEnumerable<OrderParams> books);
    }
    public struct OrderParams
    {
        public Guid book;

        public bool isVirtual;
    }
}
