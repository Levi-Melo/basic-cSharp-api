using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Order.UseCases
{
    public class OrderUpdateUseCase(IOrderRepository repo) : UpdateUseCase<OrderModel>(repo), IOrderUpdateUseCase
    {
    }
}
