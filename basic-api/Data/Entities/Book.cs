using basic_api.Data.Entities.Base;
using basic_api.Infrastructure.Database.Models;
using System;

namespace basic_api.Data.Entities
{
    public interface IBook : IBaseEntity
    {
        string Title { get; set; }

        string Synopsis { get; set; }

        IEnumerable<GenreModel> Genres { get; set; }

        int Pages { get; set; }

        WriterModel? Ilustrator { get; set; }

        PublisherModel Publisher { get; set; }

        string Stamp { get; set; }

        DateTime PublishedAt { get; set; }

        bool? Vocabulary { get; set; }

        int Edition { get; set; }

        IEnumerable<OrderModel>? Orders { get; set; }

        IEnumerable<WriterModel> Author { get; set; }

        IEnumerable<WriterModel> Reviewer { get; set; }

        WriterModel? Translator { get; set; }
    }
}
