using basic_api.Domain.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class BaseEntity : IBaseEntity
    {
        // Base
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        
        // Audit
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public List<Guid>? updated_id { get; set; }
        public Guid created_id { get; set; }
        public List<Guid>? deleted_id { get; set; }
        
        // SoftDeletable
        public bool deleted { get; set; }
    }
}
