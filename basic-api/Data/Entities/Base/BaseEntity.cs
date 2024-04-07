using System.Reflection;

namespace basic_api.Data.Entities.Base
{
    public interface IBaseEntity : IAudit, ISoftDeletable
    {
        Guid Id { get; set; }

        Guid TenantId { get; set; }
    }
}
