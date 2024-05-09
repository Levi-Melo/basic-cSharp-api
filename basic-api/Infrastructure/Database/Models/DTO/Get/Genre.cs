namespace basic_api.Infrastructure.Database.Models.DTO.Get
{
    public class GenreGetModel : GenreModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        public IEnumerable<BookGetModel>? Books { get; set; }

        public IEnumerable<WriterGetModel>? Writers { get; set; }

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
