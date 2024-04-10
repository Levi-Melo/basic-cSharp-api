using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class StockModel : BaseEntity, IStock
    {
        public BookModel Item { get; set; }

        public LocationModel? Location { get; set; }

        public byte[]? File { get; set; }

        public bool HaveFile { get; set; }

        public bool Reserved { get; set; }
    }
}
