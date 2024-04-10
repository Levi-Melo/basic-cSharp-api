using basic_api.Data.Entities;
using basic_api.Data.Entities.Enum;

namespace basic_api.Infrastructure.Database.Models
{
    public class RoleModel : BaseEntity, IRole
    {
        public RoleNameEnum Name { get; set; }

        public IEnumerable<string> AuthorizedPaths { get; set; }
    }
}
