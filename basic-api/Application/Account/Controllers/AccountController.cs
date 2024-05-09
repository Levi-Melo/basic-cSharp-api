using basic_api.Controllers;
using basic_api.Domain.Account.Controllers;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;
using basic_api.Domain.Account.Facade;
using basic_api.Data.Repositories;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Application.Account.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController(IAccountFacade facade) : Controller<AccountModel, AccountGetModel, AccountUpdateModel>(), IAccountController
    {
        readonly IAccountFacade _facade = facade;

        [HttpDelete, Route("[controller]")]
        public override void Delete(AccountGetModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public override void Delete(IEnumerable<AccountGetModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public override AccountModel Get(AccountGetModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public override IEnumerable<AccountModel> Get(GetManyParams<AccountGetModel> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public override AccountModel Insert(AccountModel entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public override IEnumerable<AccountModel> Insert(IEnumerable<AccountModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/signIn")]
        public string SignIn(string email, string password)
        {
            return _facade.SignIn(email, password);
        }

        [HttpPatch, Route("[controller]")]
        public override AccountModel Update(AccountUpdateModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public override IEnumerable<AccountModel> Update(IEnumerable<AccountUpdateModel> input)
        {
            return _facade.Update(input);
        }
    }
}
