using basic_api.Application.Stock.UseCases;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Order.UseCases
{
    public class ReplyOrderUseCase(OrderRepository repo, StockGetUseCase getStock, OrderGetUseCase getOrder) : IReplyOrderUseCase
    {
        readonly OrderGetUseCase _getOrder = getOrder;
        readonly StockGetUseCase _getStock = getStock;
        readonly OrderRepository _repo = repo;
        public OrderModel Execute(bool accept, Guid order)
        {
            var orderInput = new OrderModel()
            {
                Id = order,
                Accept = accept
            };

            if(orderInput.Accept != false) {
                var orderItem = _getOrder.Execute(orderInput);
                var validStocks = new List<StockModel>();
                var invalidBooks = new List<BookModel>();
                var booksLocation = new List<LocationModel>();
                
                foreach(var book in orderItem.Books)
                {
                    var stock = new StockModel()
                    {
                        Item = book
                    };
                    var searchedStocks = _getStock.Execute([stock]);
                    var invalidBook = book;
                    foreach(var stocked in searchedStocks)
                    {
                        if(stocked.Reserved == false)
                        {
                            validStocks.Add(stocked);
                            invalidBook = null;
                            if (stocked.Location != null) booksLocation.Add(stocked.Location);
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

                orderInput.Locations = booksLocation;
            }

            return _repo.Update(orderInput);
        }
    }
}
