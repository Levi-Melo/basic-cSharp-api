using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IBook : IBaseEntity
    {
        string Title { get; set; }

        string Synopsis { get; set; }

        IEnumerable<IGenre> Genres { get; set; }

        int Pages { get; set; }

        string? Ilustrator { get; set; }

        IPublisher Publisher { get; set; }

        string Stamp { get; set; }

        DateTime PublishedAt { get; set; }

        bool? Vocabulary { get; set; }

        int Edition { get; set; }

        IEnumerable<IWriter> Author { get; set; }

        IEnumerable<IWriter> Reviewer { get; set; }

        IWriter? Translator { get; set; }
    }
}
