using basic_api.Application.Account.UseCases;
using basic_api.Application.Stock.UseCases;
using basic_api.Domain.Order.UseCases;
using basic_api.Domain.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Services;

namespace basic_api.Application.Order.UseCases
{
    public class ReplyOrderUseCase(OrderRepository repo, StockGetUseCase getStock, StockUpdateUseCase updateUseCase, OrderGetUseCase getOrder, EmailService emailService, AccountGetUseCase getAccount) : IReplyOrderUseCase
    {
        private readonly AccountGetUseCase _getAccount = getAccount;
        private readonly StockUpdateUseCase _updateUseCase = updateUseCase;
        private readonly OrderGetUseCase _getOrder = getOrder;
        private readonly StockGetUseCase _getStock = getStock;
        private readonly EmailService _emailService = emailService;
        private readonly OrderRepository _repo = repo;
        async public Task<OrderModel> Execute(bool accept, Guid order)
        {
            var orderInput = new OrderModel()
            {
                Id = order,
                Deleted = false
            };

            var validStocks = new List<StockModel>();
            var invalidBooks = new List<BookModel>();
            var orderItem = _getOrder.Execute(orderInput);
            var account = _getAccount.Execute(orderItem.OrderAuthor);
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
                    return _repo.Update(orderInput);
                }

                orderItem.StockBooks = validStocks;

                foreach (var stock in orderItem.StockBooks)
                {
                    stock.Reserved = true;
                }
                await _updateUseCase.Execute(orderItem.StockBooks);
            }

            orderItem.Accept = accept;

            var acceptMessage = orderItem.Accept == true ? "Aceito" : "Recusado";

            await _emailService.Send(account.Email, $"Pedido {acceptMessage}", $"Pedido {orderItem.Id} foi {acceptMessage.ToLower()}");
            
            return _repo.Update(orderItem);
        }
    }
}
