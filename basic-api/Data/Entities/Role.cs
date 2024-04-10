using basic_api.Data.Entities.Base;
using basic_api.Data.Entities.Enum;

namespace basic_api.Data.Entities
{
    public interface IRole : IBaseEntity
    {
        RoleNameEnum Name { get; set; }

        IEnumerable<string> AuthorizedPaths { get; set; }
    }
}
