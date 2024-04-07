using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class Writer : BaseEntity, IWriter
    {
        public string name { get; set; }

        public string description { get; set; }

        public IEnumerable<IBook> books { get; set; }

        public IEnumerable<string> genres { get; set; }

        public string nation { get; set; }

        public bool isTranslator { get; set; }
    }
}
