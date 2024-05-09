namespace basic_api.Infrastructure.Database.Models.DTO.Get
{
    public class BookGetModel : BookModel
    {
        public Guid? Id { get; set; }

        public string? Title { get; set; }

        public string? Synopsis { get; set; }

        public int? Pages { get; set; }

        public WriterGetModel? Ilustrator { get; set; }

        public PublisherGetModel? Publisher { get; set; }

        public string? Stamp { get; set; }

        public DateTime? PublishedAt { get; set; }

        public bool? Vocabulary { get; set; }

        public int? Edition { get; set; }

        public string? Material { get; set; }

        public IEnumerable<WriterGetModel>? Author { get; set; }

        public IEnumerable<WriterGetModel>? Reviewer { get; set; }

        public WriterGetModel? Translator { get; set; }
        
        public IEnumerable<OrderGetModel>? Orders { get; set; }
        
        public IEnumerable<GenreGetModel>? Genres { get; set; }

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
