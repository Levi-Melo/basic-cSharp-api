using basic_api.Domain.Base.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Account.Facade
{
    public interface IAccountFacade : IFacade<AccountModel>
    {
        string SignIn(string email, string password);
    }
}
