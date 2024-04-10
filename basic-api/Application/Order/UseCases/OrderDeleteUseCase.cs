using basic_api.Application.Base.UseCase;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Order.UseCases
{
    public class OrderDeleteUseCase(OrderRepository repo) : DeleteUseCase<OrderModel>(repo), IOrderDeleteUseCase
    {
    }
}
