namespace basic_api.Infrastructure.Database.Models.DTO.Get
{
    public class AccountGetModel : AccountModel
    {
        public Guid? Id { get; set; }
        
        public string? Name { get; set; }

        public string? Document { get; set; }
        
        public string? Password { get; set; }
        
        public string? Email { get; set; }
        
        public string? Phone { get; set; }
        
        public RoleGetModel? Role { get; set; }

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
