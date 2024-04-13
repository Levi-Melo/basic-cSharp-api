using basic_api.Application.Base;
using basic_api.Domain.Account.Facade;
using basic_api.Domain.Account.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Account.Facade
{
    public class AccountFacade(
        IAccountGetUseCase accountGetUseCase,
        IAccountDeleteUseCase accountDeleteUseCase,
        IAccountInsertUseCase accountInsertUseCase,
        IAccountUpdateUseCase accountUpdateUseCase,
        IAccountSignInUseCase accountSignInUseCase
        ) : Facade<AccountModel>(
            accountGetUseCase,
            accountDeleteUseCase,
            accountInsertUseCase,
            accountUpdateUseCase), IAccountFacade
    {

        readonly IAccountSignInUseCase _accountSignInUseCase = accountSignInUseCase;
        public string SignIn(string email, string password)
        {
           return  _accountSignInUseCase.Execute(email, password);
        }
    }
}
