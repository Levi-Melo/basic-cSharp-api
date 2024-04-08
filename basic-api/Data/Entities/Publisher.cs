using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IPublisher : IBaseEntity
    {
        string Name { get; set; }

        IEnumerable<IBook> Books { get; set; }

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
