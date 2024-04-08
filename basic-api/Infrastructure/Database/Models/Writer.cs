using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class WriterModel : BaseEntity, IWriter
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<IBook> Books { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public string Nation { get; set; }

        public bool IsTranslator { get; set; }
    }
}
