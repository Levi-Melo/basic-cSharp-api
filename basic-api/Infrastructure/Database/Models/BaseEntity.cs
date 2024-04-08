using basic_api.Data.Entities.Base;

namespace basic_api.Infrastructure.Database.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        // Base
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        
        // Audit
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        public List<Guid>? Updated_id { get; set; }
        public Guid Created_id { get; set; }
        public List<Guid>? Deleted_id { get; set; }
        
        // SoftDeletable
        public bool Deleted { get; set; }
    }
}
