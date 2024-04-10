using BCrypt.Net;
using basic_api.Domain.Account.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Services;
using basic_api.Data.Entities.Enum;

namespace basic_api.Application.Account.UseCases
{
    public class AccountSignInUseCase(AccountRepository repo, AuthService<AuthPayload> authService) : IAccountSignInUseCase
    {
        private readonly AccountRepository _repo = repo;
        
        private readonly AuthService<AuthPayload> _authService = authService;
        public string Execute(string email, string password)
        {
            var search = new AccountModel() 
            { 
                Email = email,
                Deleted = false
            };
            var user = _repo.Get(search);

            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password);
            var payload = new AuthPayload
            {
                Id = user.Id,
                TenantId = user.Tenant.Id,
                role = user.Role.Name
            };

            if (!isPasswordCorrect) throw new InvalidOperationException("UNAUTHORIZED");


            return _authService.SignIn(payload);
        }


    }
    public struct AuthPayload
    {
        public Guid Id;
        public Guid TenantId;
        public RoleNameEnum role;
  
    }
}
