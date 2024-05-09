using basic_api.Data.Entities.Enum;

namespace basic_api.Infrastructure.Database.Models.DTO.Get
{
    public class RoleGetModel : RoleModel
    {
        public Guid? Id { get; set; }

        public RoleNameEnum? Name { get; set; }

        public IEnumerable<string>? AuthorizedPaths { get; set; }

        public TenantGetModel? Tenant { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public DateTime? Deleted_at { get; set; }

        public List<Guid>? Updated_id { get; set; }

        public Guid? Created_id { get; set; }

        public List<Guid>? Deleted_id { get; set; }

        public bool? Deleted { get; set; }
    }
}
