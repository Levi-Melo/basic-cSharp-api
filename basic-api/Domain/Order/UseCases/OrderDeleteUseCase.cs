using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Order.UseCases
{
    public interface IOrderDeleteUseCase: IDeleteUseCase<OrderModel>
    {
    }
}
