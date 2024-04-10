using basic_api.Data.Entities.Base;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Data.Entities
{
    public interface IGenre : IBaseEntity
    {
        string Name { get; set; }

        string Description { get; set; }

        IEnumerable<BookModel> Books { get; set; }
    }
}