using basic_api.Application.Account.UseCases;
using basic_api.Application.Base.UseCase;
using basic_api.Application.Book.UseCases;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Services;

namespace basic_api.Application.Order.UseCases
{
    public class OrderInsertUseCase(OrderRepository repo, AccountGetUseCase getAccount, BookGetUseCase getBook, EmailService emailService) : InsertUseCase<OrderModel>(repo), IOrderInsertUseCase
    {
        private readonly EmailService _emailService = emailService;
        private readonly AccountGetUseCase _getAccount = getAccount;
        private readonly OrderRepository _repo = repo;
        private readonly BookGetUseCase _getBook = getBook;

        public async Task<OrderModel> ExecuteAsync(Guid userId, IEnumerable<OrderParams> books)
        {
            var user = new AccountModel()
            {
                Id = userId,
                Deleted = false
            };

            var validUser = IsValidUser(user);

            if (validUser == null)
            {
                throw new Exception();
            };

            var searchedBookParams = new List<BookModel>();

            foreach (var book in books)
            {
                var Book = new BookModel() 
                { 
                    Id = book.book,
                    Deleted = false
                };

                searchedBookParams.Add(Book);
            }

            var foundBooks = _getBook.Execute(searchedBookParams);

            if (foundBooks.Count() != books.Count())
            {
                throw new Exception();
            }

            var orderInput = new OrderModel()
            {
                Books = foundBooks,
                OrderAuthor = user,
            };


            var created =  Execute(orderInput);

            await _emailService.Send(validUser.Email, "Pedido Efetuado", $"Pedido {created.Id} aguardando aprovação");

            return created;
        }

        private AccountModel? IsValidUser(AccountModel user)
        {
            var found = _getAccount.Execute(user);

            var expiredOrder = new OrderModel()
            {
                OrderAuthor = user,
                Devolved = false,
                Deleted = false
            };

            var activeOrder = new OrderModel()
            {
                OrderAuthor = user,
                Devolved = null,
                Deleted = false
            };


            var foundOrders = _repo.Get([expiredOrder, activeOrder]);

            if (foundOrders.Any())
            {
                return null;
            }

            return found;
        }
    }
}
