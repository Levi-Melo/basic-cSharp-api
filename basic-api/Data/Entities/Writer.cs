using basic_api.Data.Entities.Base;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Data.Entities
{
    public interface IWriter : IBaseEntity
    {
        string Name { get; set; }

        string Description { get; set; }

        IEnumerable<BookModel> Books { get; set; }

        IEnumerable<GenreModel> Genres { get; set; }

        string Nation { get; set; }

        bool IsTranslator { get; set; }
    }
}
