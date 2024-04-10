using basic_api.Data.Entities.Base;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Data.Entities
{
    public interface ILocation: IBaseEntity 
    { 
        string Name { get; set; }

        object Metadata { get; set; }

        IEnumerable<BookModel> Books { get; set; }
    }
}
