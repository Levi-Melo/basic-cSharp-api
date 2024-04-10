using basic_api.Application.Base.UseCase;
using basic_api.Domain.Account.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Account.UseCases
{
    public class AccountDeleteUseCase(AccountRepository repo) : DeleteUseCase<AccountModel>(repo), IAccountDeleteUseCase
    {
    }
}
