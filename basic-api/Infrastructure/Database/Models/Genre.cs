using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class GenreModel : BaseEntity, IGenre
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<BookModel> Books { get; set; }
    }
}
