using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class BookModel : BaseEntity, IBook
    {
        public string title { get; set; }

        public string synopsis { get; set; }

        public int pages { get; set; }

        public string? ilustrator { get; set; }

        public IPublisher publisher { get; set; }

        public string stamp { get; set; }

        public DateTime published_at { get; set; }

        public bool? vocabulary { get; set; }

        public int edition { get; set; }

        public string? material { get; set; }

        public IEnumerable<IWriter> author { get; set; }

        public IEnumerable<IWriter> reviewer { get; set; }

        public IWriter? translator { get; set; }
        
        public IEnumerable<IGenre> genres { get; set; }
    }
}
