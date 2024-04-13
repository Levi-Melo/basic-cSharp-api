using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Account.UseCases;
using basic_api.Data.Repositories;

namespace basic_api.Application.Account.UseCases
{
    public class AccountGetUseCase(IAccountRepository repo) : GetUseCase<AccountModel>(repo), IAccountGetUseCase
    {
    }
}
