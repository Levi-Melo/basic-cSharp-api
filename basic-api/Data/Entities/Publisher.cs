using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IPublisher : IBaseEntity
    {
        string name { get; set; }

        IEnumerable<IBook> books { get; set; }

        string document { get; set; }

        IAddress address { get; set; }
    }

    public struct IAddress
    {
        string postalCode { get; set; }

        int number { get; set; }

        string street { get; set; }

        string district { get; set; }
    }
}
