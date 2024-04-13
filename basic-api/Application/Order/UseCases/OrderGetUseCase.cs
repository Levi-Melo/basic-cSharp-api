using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Order.UseCases;
using basic_api.Data.Repositories;

namespace basic_api.Application.Order.UseCases
{
    public class OrderGetUseCase(IOrderRepository repo) : GetUseCase<OrderModel>(repo), IOrderGetUseCase
    {
    }
}
