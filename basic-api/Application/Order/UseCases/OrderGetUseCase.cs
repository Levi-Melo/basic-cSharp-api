using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Order.UseCases;

namespace basic_api.Application.Order.UseCases
{
    public class OrderGetUseCase(OrderRepository repo) : GetUseCase<OrderModel>(repo), IOrderGetUseCase
    {
    }
}
