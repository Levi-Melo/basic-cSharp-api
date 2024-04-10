using basic_api.Data.Entities.Base;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Data.Entities
{
    public interface IPublisher : IBaseEntity
    {
        string Name { get; set; }

        IEnumerable<BookModel> Books { get; set; }

        string Document { get; set; }

        IAddress Address { get; set; }
    }

    public interface IAddress
    {
        string PostalCode { get; set; }

        int Number { get; set; }

        string Street { get; set; }

        string District { get; set; }
    }
}
