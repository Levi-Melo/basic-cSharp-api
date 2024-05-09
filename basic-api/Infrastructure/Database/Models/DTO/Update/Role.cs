using basic_api.Data.Entities.Enum;
using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Infrastructure.Database.Models.DTO.Update
{
    public class RoleUpdateModel : RoleGetModel
    {
        public Guid Id { get; set; }
    }
}
