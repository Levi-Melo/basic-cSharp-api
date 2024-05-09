namespace basic_api.Infrastructure.Database.Models.DTO.Get
{
    public class TenantGetModel : TenantModel
    {
        public Guid? Id { get; set; }
        
        public string? Name { get; set; }
        
        public string? Document { get; set; }
        
        public string? ValidUntil { get; set; }
        
        public string? Email { get; set; }
        
        public string? Phone { get; set; }
        
        public DateTime? DueDate { get; set; }
        
        public Guid? Created_id { get; set; }
        
        public DateTime? Created_at { get; set; }
        
        public List<Guid>? Updated_id { get; set; }
        
        public DateTime? Updated_at { get; set; }
        
        public List<Guid>? Deleted_id { get; set; }
        
        public DateTime? Deleted_at { get; set; }
        
        public bool? Deleted { get; set; }
    }
}
