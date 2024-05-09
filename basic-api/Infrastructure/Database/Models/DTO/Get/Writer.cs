namespace basic_api.Infrastructure.Database.Models.DTO.Get
{
    public class WriterGetModel : WriterModel
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<BookGetModel>? Books { get; set; }

        public IEnumerable<GenreGetModel>? Genres { get; set; }

        public string? Nation { get; set; }

        public bool? IsTranslator { get; set; }

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
