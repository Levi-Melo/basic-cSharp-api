using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class WriterModel : BaseEntity, IWriter
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<BookModel> Books { get; set; }

        public IEnumerable<GenreModel> Genres { get; set; }

        public string Nation { get; set; }

        public bool IsTranslator { get; set; }
    }
}
