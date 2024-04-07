using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IBook : IBaseEntity
    {
        string title { get; set; }

        string synopsis { get; set; }

        IEnumerable<IGenre> genres { get; set; }

        int pages { get; set; }

        string? ilustrator { get; set; }

        IPublisher publisher { get; set; }

        string stamp { get; set; }

        DateTime published_at { get; set; }

        bool? vocabulary { get; set; }

        int edition { get; set; }

        IEnumerable<IWriter> author { get; set; }

        IEnumerable<IWriter> reviewer { get; set; }

        IWriter? translator { get; set; }
    }
}
