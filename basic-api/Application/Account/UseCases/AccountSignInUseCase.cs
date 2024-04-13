using BCrypt.Net;
using basic_api.Domain.Account.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Data.Entities.Enum;
using basic_api.Data.Repositories;
using basic_api.Data.Services;
using basic_api.Infrastructure.Utils;

namespace basic_api.Application.Account.UseCases
{
    public class AccountSignInUseCase(IAccountRepository repo, IAuthService<AuthPayload> authService) : IAccountSignInUseCase
    {
        private readonly IAccountRepository _repo = repo;
        
        private readonly IAuthService<AuthPayload> _authService = authService;
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
    public record AuthPayload : RecordMarker
    {
        public Guid Id;
        public Guid TenantId;
        public RoleNameEnum role;
  
    }
}
