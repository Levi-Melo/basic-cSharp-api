using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Data.Services;
using basic_api.Domain.Account.UseCases;
using basic_api.Domain.Book.UseCases;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Order.UseCases
{
    public class OrderInsertUseCase(IOrderRepository repo, IAccountGetUseCase getAccount, IBookGetUseCase getBook, IEmailService emailService) : InsertUseCase<OrderModel>(repo), IOrderInsertUseCase
    {
        private readonly IEmailService _emailService = emailService;
        private readonly IAccountGetUseCase _getAccount = getAccount;
        private readonly IOrderRepository _repo = repo;
        private readonly IBookGetUseCase _getBook = getBook;

        public async Task<OrderModel> ExecuteAsync(Guid userId, IEnumerable<OrderParams> books)
        {
            var user = new AccountModel()
            {
                Id = userId,
                Deleted = false
            };

            var validUser = IsValidUser(user) ?? throw new Exception();
            ;

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

            GetManyParams<BookModel> param = new()
            {
                Where = searchedBookParams
            };

            var foundBooks = _getBook.Execute(param);

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


            GetManyParams<OrderModel> param = new()
            {
                Where = [expiredOrder, activeOrder],
                NotPage = true
            };
            var foundOrders = _repo.Get(param);

            if (foundOrders.Any())
            {
                return null;
            }

            return found;
        }
    }
}
