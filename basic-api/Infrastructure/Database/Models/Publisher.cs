using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class PublisherModel : BaseEntity, IPublisher
    {
        public string Name { get; set; }

        public IEnumerable<IBook> Books { get; set; }

        public string Document { get; set; }

        public IAddress Address { get; set; }
    }
}
