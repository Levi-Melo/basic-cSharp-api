using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Infrastructure.Database.Models.DTO.Update
{
    public class AccountUpdateModel : AccountGetModel
    {
        public Guid Id { get; set; }

        public RoleUpdateModel? Role { get; set; }

        public TenantUpdateModel? Tenant { get; set; }
    }
}
