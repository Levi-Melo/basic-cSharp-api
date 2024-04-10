using basic_api.Data.Entities.Base;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Data.Entities
{
    public interface IStock : IBaseEntity
    {
        BookModel Item { get; set; }

        LocationModel? Location { get; set; }

        bool Reserved { get; set; }
    }
}
