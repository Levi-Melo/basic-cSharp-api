using basic_api.Data.Entities.Base;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Data.Entities
{
    public interface IOrder : IBaseEntity
    {
        IEnumerable<BookModel> Books { get; set; }

        bool? Accept { get; set; }

        IEnumerable<StockModel> StockBooks { get; set; }

        DateTime? DevolveAt { get; set; }

        IEnumerable<BookModel> InvalidBooks { get; set; }

        bool? Devolved { get; set; }

        AccountModel OrderAuthor { get; set; }
    }
}
