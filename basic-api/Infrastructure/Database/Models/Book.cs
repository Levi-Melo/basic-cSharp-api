using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class BookModel : BaseEntity, IBook
    {
        public string Title { get; set; }

        public string Synopsis { get; set; }

        public int Pages { get; set; }

        public WriterModel? Ilustrator { get; set; }

        public PublisherModel Publisher { get; set; }

        public string Stamp { get; set; }

        public DateTime PublishedAt { get; set; }

        public bool? Vocabulary { get; set; }

        public int Edition { get; set; }

        public string? Material { get; set; }

        public IEnumerable<WriterModel> Author { get; set; }

        public IEnumerable<WriterModel> Reviewer { get; set; }

        public WriterModel? Translator { get; set; }
        
        public IEnumerable<GenreModel> Genres { get; set; }
    }
}
