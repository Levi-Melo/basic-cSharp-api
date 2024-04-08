using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IWriter : IBaseEntity
    {
        string Name { get; set; }

        string Description { get; set; }

        IEnumerable<IBook> Books { get; set; }

        IEnumerable<string> Genres { get; set; }

        string Nation { get; set; }

        bool IsTranslator { get; set; }

    }
}
