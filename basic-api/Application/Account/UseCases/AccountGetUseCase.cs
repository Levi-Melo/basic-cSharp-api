using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Account.UseCases;

namespace basic_api.Application.Account.UseCases
{
    public class AccountGetUseCase(AccountRepository repo) : GetUseCase<AccountModel>(repo), IAccountGetUseCase
    {
    }
}
