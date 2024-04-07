using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IWriter : IBaseEntity
    {
        string name { get; set; }

        string description { get; set; }

        IEnumerable<IBook> books { get; set; }

        IEnumerable<string> genres { get; set; }

        string nation { get; set; }

        bool isTranslator { get; set; }

    }
}
