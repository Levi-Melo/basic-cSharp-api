using System.Reflection;

namespace basic_api.Domain.Entities
{
    public interface IBaseEntity : IAudit, ISoftDeletable
    {
        Guid Id { get; set; }

        Guid TenantId { get; set; }
    }
}
