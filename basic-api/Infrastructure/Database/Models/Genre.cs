using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class Genre : BaseEntity, IGenre
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
