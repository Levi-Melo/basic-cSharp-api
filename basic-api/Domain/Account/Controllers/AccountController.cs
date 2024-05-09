using basic_api.Domain.Base.Controller;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Domain.Account.Controllers
{
    public interface IAccountController : IController<AccountModel, AccountGetModel, AccountUpdateModel>
    {
        string SignIn(string email, string password);
    }
}
