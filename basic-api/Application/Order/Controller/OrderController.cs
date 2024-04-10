using basic_api.Application.Order.Facade;
using basic_api.Controllers;
using basic_api.Domain.Order.Controller;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Order.Controller
{
    [ApiController]
    [Route("orders")]
    public class OrderController(OrderFacade facade) : Controller<OrderModel>(facade), IOrderController
    {
        private readonly OrderFacade _facade = facade;

        [HttpGet(Name = "stocks")]
        public async Task<IEnumerable<StockModel>> AccessOrderStooks(Guid user, Guid order)
        {
            return await _facade.AccessOrderStooks(user, order);
        }

        [HttpPost(Name = "devolve")]
        public async Task<OrderModel> Devolve(Guid order, IEnumerable<StockModel> stocks)
        {
            return await _facade.Devolve(order, stocks);
        }

        [HttpPost(Name = "")]
        public OrderModel Insert(Guid userId, IEnumerable<OrderParams> books)
        {
            return _facade.Insert(userId, books);
        }

        [HttpPost(Name = "Reply")]
        public async Task<OrderModel> Reply(bool accept, Guid order)
        {
            return await _facade.Reply(accept, order);
        }
    }
}
