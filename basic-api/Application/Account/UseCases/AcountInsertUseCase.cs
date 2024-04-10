using BCrypt.Net;
using basic_api.Application.Base.UseCase;
using basic_api.Domain.Account.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Account.UseCases
{
    public class AccountInsertUseCase(AccountRepository repo) : InsertUseCase<AccountModel>(repo), IAccountInsertUseCase
    {
        public AccountModel Execute(AccountModel input)
        {
            input.Password = BCrypt.Net.BCrypt.HashPassword(input.Password);
            return base.Execute(input);
        }

        public IEnumerable<AccountModel> Execute(IEnumerable<AccountModel> input) { 

            foreach(var item in input){
                item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
            }

            return base.Execute(input);
        }

    }
}
