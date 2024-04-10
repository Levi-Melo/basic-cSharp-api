using basic_api.Application.Account.UseCases;
using basic_api.Application.Base.UseCase;
using basic_api.Application.Book.UseCases;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Order.UseCases
{
    public class OrderInsertUseCase(OrderRepository repo, AccountGetUseCase getAccount, BookGetUseCase getBook) : InsertUseCase<OrderModel>(repo), IOrderInsertUseCase
    {
        AccountGetUseCase _getAccount = getAccount;
        BookGetUseCase _getBook = getBook;

        public OrderModel Execute(Guid userId, IEnumerable<OrderParams> books)
        {
            var userParams = new AccountModel()
            {
                Id = userId
            };

            var foundUser = _getAccount.Execute(userParams);

            var searchedStock = new List<BookModel>();

            foreach (var book in books)
            {
                var Book = new BookModel() { Id = book.book };

                searchedStock.Add(Book);
            }

            var founBooks = _getBook.Execute(searchedStock);

            if (founBooks.Count() != books.Count())
            {
                throw new Exception();
            }

            var orderInput = new OrderModel()
            {
                Books = founBooks,
                OrderAuthor = foundUser
            };

            return Execute(orderInput);
        }
    }
}
