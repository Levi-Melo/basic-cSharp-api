using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Infrastructure.Database.Models.DTO.Update
{
    public class TenantUpdateModel : TenantGetModel
    {
        public Guid Id { get; set; }
    }
}
