using basic_api.Application.Base.UseCase;
using basic_api.Domain.Account.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Account.UseCases
{
    public class AccountUpdateUseCase(AccountRepository repo) : UpdateUseCase<AccountModel>(repo), IAccountUpdateUseCase
    {
        new public AccountModel Execute(AccountModel input)
        {
            if(input.Password != null)
            {
                input.Password = BCrypt.Net.BCrypt.HashPassword(input.Password);
            }

            return base.Execute(input);
        }

        new  public IEnumerable<AccountModel> Execute(IEnumerable<AccountModel> input)
        {

            foreach (var item in input)
            {
                if(item.Password != null)
                {
                item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
                }
            }

            return base.Execute(input);
        }

    }
}
