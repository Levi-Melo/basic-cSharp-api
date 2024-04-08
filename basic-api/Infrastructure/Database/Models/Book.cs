using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class BookModel : BaseEntity, IBook
    {
        public string Title { get; set; }

        public string Synopsis { get; set; }

        public int Pages { get; set; }

        public string? Ilustrator { get; set; }

        public IPublisher Publisher { get; set; }

        public string Stamp { get; set; }

        public DateTime PublishedAt { get; set; }

        public bool? Vocabulary { get; set; }

        public int Edition { get; set; }

        public string? Material { get; set; }

        public IEnumerable<IWriter> Author { get; set; }

        public IEnumerable<IWriter> Reviewer { get; set; }

        public IWriter? Translator { get; set; }
        
        public IEnumerable<IGenre> Genres { get; set; }
    }
}
