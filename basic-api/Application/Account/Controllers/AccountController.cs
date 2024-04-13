using basic_api.Controllers;
using basic_api.Domain.Account.Controllers;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;
using basic_api.Domain.Account.Facade;

namespace basic_api.Application.Account.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController(IAccountFacade facade) : Controller<AccountModel>(facade), IAccountController
    {
        readonly IAccountFacade _facade = facade;
        
        [HttpPost("signIn")]
        public string SignIn(string email, string password)
        {
            return _facade.SignIn(email, password);
        }
    }
}
