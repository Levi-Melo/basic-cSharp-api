using basic_api.Infrastructure.Database.Models;
using System.Reflection;

namespace basic_api.Data.Entities.Base
{
    public interface IBaseEntity : IAudit, ISoftDeletable
    {
        Guid Id { get; set; }

        TenantModel Tenant { get; set; }
    }
}
