using basic_api.Controllers;
using basic_api.Data.Repositories;
using basic_api.Domain.Order.Controller;
using basic_api.Domain.Order.Facade;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace basic_api.Application.Order.Controller
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase, IOrderController, IDisposable
    {
        private readonly IOrderFacade _facade;

        private readonly Timer _timer;
        public OrderController(IOrderFacade facade)
        {
            AddModelValidation();
            _facade = facade;
            int intervalo = 60000 * 60 * 24; // 24 hrs

            _timer = new Timer(VerifyOrders, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(intervalo));

        }

        [HttpGet, Route("[controller]/stocks")]
        public async Task<IEnumerable<StockModel>> AccessOrderStooks(Guid user, Guid order)
        {
            return await _facade.AccessOrderStooks(user, order);
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

        [HttpDelete, Route("[controller]")]
        public void Delete(OrderModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public  void Delete(IEnumerable<OrderModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public  OrderModel Get(OrderModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public  IEnumerable<OrderModel> Get(GetManyParams<OrderModel> input)
        {
            return _facade.Get(input);
        }


        [HttpPost, Route("[controller]/many")]
        public  IEnumerable<OrderModel> Insert(IEnumerable<OrderModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public  OrderModel Update(OrderModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public  IEnumerable<OrderModel> Update(IEnumerable<OrderModel> input)
        {
            return _facade.Update(input);
        }
        
        private void VerifyOrders(object state)
        {
            _facade.VerifyOrdersStatus().Wait();
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void AddModelValidation()
        {
            MethodInfo[] methods = GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                // Ignora métodos especiais (como construtores)
                if (method.IsSpecialName)
                    continue;

                // Obtém o delegate da função original
                Action originalMethod = (Action)Delegate.CreateDelegate(typeof(Action), this, method);

                // Substitui a função original por uma nova função que chama o bloco de código primeiro
                Action newMethod = () =>
                {
                    if (!ModelState.IsValid)
                    {
                        throw new Exception();
                    }
                    originalMethod(); // Chama a função original
                };

                // Atualiza o método para a nova função
                Delegate.Combine(originalMethod, newMethod);
            }
        }
    }
}
