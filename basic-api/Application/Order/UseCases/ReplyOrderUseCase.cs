using basic_api.Application.Stock.UseCases;
using basic_api.Domain.Order.UseCases;
using basic_api.Domain.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Order.UseCases
{
    public class ReplyOrderUseCase(OrderRepository repo, StockGetUseCase getStock, StockUpdateUseCase updateUseCase, OrderGetUseCase getOrder) : IReplyOrderUseCase
    {
        readonly StockUpdateUseCase _updateUseCase = updateUseCase;
        readonly OrderGetUseCase _getOrder = getOrder;
        readonly StockGetUseCase _getStock = getStock;
        readonly OrderRepository _repo = repo;
        async public Task<OrderModel> Execute(bool accept, Guid order)
        {
            var orderInput = new OrderModel()
            {
                Id = order,
                Accept = accept,
                Deleted = false
            };

            var validStocks = new List<StockModel>();
            var invalidBooks = new List<BookModel>();

            if(orderInput.Accept != false) {
                var orderItem = _getOrder.Execute(orderInput);
                
                foreach(var book in orderItem.Books)
                {
                    var stock = new StockModel()
                    {
                        Item = book,
                        Deleted = false
                    };
                    var searchedStocks = await _getStock.Execute([stock]);
                    var invalidBook = book;
                    foreach(var stocked in searchedStocks)
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

                orderInput.InvalidBooks = invalidBooks;

                if(orderInput.InvalidBooks.Count() == orderInput.Books.Count())
                {
                    orderInput.Accept = false;
                    return _repo.Update(orderInput);
                }
                orderInput.StockBooks = validStocks;
            }
            foreach(var book in orderInput.StockBooks)
            {
                book.Reserved = true;
            }
            
            await _updateUseCase.Execute(orderInput.StockBooks);
            
            return _repo.Update(orderInput);
        }
    }
}
