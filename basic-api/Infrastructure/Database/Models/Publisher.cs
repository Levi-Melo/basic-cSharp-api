using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class Publisher : BaseEntity, IPublisher
    {
        public string name { get; set; }

        public IEnumerable<IBook> books { get; set; }

        public string document { get; set; }

        public IAddress address { get; set; }
    }
}
