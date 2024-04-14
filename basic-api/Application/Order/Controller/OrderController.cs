using basic_api.Application.Order.Facade;
using basic_api.Controllers;
using basic_api.Domain.Order.Controller;
using basic_api.Domain.Order.Facade;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Order.Controller
{
    [ApiController]
    [Route("orders")]
    public class OrderController : Controller<OrderModel>, IOrderController, IDisposable
    {
        private readonly IOrderFacade _facade;

        private readonly Timer _timer;
        public OrderController(IOrderFacade facade) : base(facade)
        {
            _facade = facade;
            int intervalo = 60000 * 60 * 24; // 24 hrs

            _timer = new Timer(VerifyOrders, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(intervalo));

        }

        [HttpGet, Route("[controller]/stocks")]
        public async Task<IEnumerable<StockModel>> AccessOrderStooks(Guid user, Guid order)
        {
            return await _facade.AccessOrderStooks(user, order);
        }

        public  void VerifyOrders(object state)
        {
             _facade.VerifyOrdersStatus().Wait();
        }

        [HttpPost, Route("[controller]/devolve")]
        public async Task<OrderModel> Devolve(Guid order, IEnumerable<StockModel> stocks)
        {
            return await _facade.Devolve(order, stocks);
        }

        [HttpPost, Route("[controller]")]
        public async Task<OrderModel> Insert(Guid userId, IEnumerable<OrderParams> books)
        {
            return await _facade.Insert(userId, books);
        }

        [HttpPost, Route("[controller]/reply")]
        public async Task<OrderModel> Reply(bool accept, Guid order)
        {
            return await _facade.Reply(accept, order);
        }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timer?.Dispose();
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
