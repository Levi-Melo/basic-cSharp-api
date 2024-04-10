﻿using basic_api.Application.Base.UseCase;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Order.UseCases
{
    public class OrderUpdateUseCase(OrderRepository repo) : UpdateUseCase<OrderModel>(repo), IOrderUpdateUseCase
    {
    }
}