using basic_api.Domain.Base.Controller;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Account.Controllers
{
    public interface IAccountController : IController<AccountModel>
    {
        string SignIn(string email, string password);
    }
}
