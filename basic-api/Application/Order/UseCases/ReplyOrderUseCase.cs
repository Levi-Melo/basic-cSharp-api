using basic_api.Data.Repositories;
using basic_api.Data.Services;
using basic_api.Domain.Account.UseCases;
using basic_api.Domain.Order.UseCases;
using basic_api.Domain.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.SignalR;

namespace basic_api.Application.Order.UseCases
{
    public class ReplyOrderUseCase(IOrderRepository repo, IStockGetUseCase getStock, IStockUpdateUseCase updateUseCase, IOrderGetUseCase getOrder, IEmailService emailService, IAccountGetUseCase getAccount) : Hub, IReplyOrderUseCase
    {
        private readonly IAccountGetUseCase _getAccount = getAccount;
        private readonly IStockUpdateUseCase _updateUseCase = updateUseCase;
        private readonly IOrderGetUseCase _getOrder = getOrder;
        private readonly IStockGetUseCase _getStock = getStock;
        private readonly IEmailService _emailService = emailService;
        private readonly IOrderRepository _repo = repo;
        async public Task<OrderModel> Execute(bool accept, Guid order)
        {
            _repo.BeginTransaction();

            var orderInput = new OrderModel()
            {
                Id = order,
                Deleted = false
            };

            var validStocks = new List<StockModel>();
            var invalidBooks = new List<BookModel>();
            var orderItem = _getOrder.Execute(orderInput);
            var account = _getAccount.Execute(orderItem.OrderAuthor);
            OrderModel result;
            if (accept != false) {
                foreach (var book in orderItem.Books)
                {
                    var stock = new StockModel()
                    {
                        Item = book,
                        Deleted = false
                    };
                    var searchedStocks = await _getStock.Execute([stock]);
                    var invalidBook = book;

                    foreach (var stocked in searchedStocks)
                    {
                        if(stocked.Reserved == false)
                        {
                            validStocks.Add(stocked);
                            invalidBook = null;
                            break;
                        }
                    }

                    if(invalidBook != null) invalidBooks.Add(book);
                }

                orderItem.InvalidBooks = invalidBooks;

                if(orderItem.InvalidBooks.Count() == orderItem.Books.Count())
                {
                    orderInput.Accept = false;

                    await _emailService.Send(account.Email, "Pedido Recusado", $"Pedido {orderItem.Id} foi recusado");
                    
                    result = _repo.Update(orderInput);

                    _repo.Commit();

                    return result;
                }

                orderItem.StockBooks = validStocks;

                foreach (var stock in orderItem.StockBooks)
                {
                    stock.Reserved = true;
                }
                await _updateUseCase.Execute(orderItem.StockBooks);
                await Clients.All.SendAsync($"{orderItem.Tenant.Id}-reserveds", orderItem.StockBooks);
            }

            orderItem.Accept = accept;

            var acceptMessage = orderItem.Accept == true ? "Aceito" : "Recusado";

            await _emailService.Send(account.Email, $"Pedido {acceptMessage}", $"Pedido {orderItem.Id} foi {acceptMessage.ToLower()}");
            
            result = _repo.Update(orderItem);

            _repo.Commit();
            
            return result;
        }
    }
}
