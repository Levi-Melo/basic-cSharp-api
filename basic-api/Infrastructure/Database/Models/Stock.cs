using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class StockModel : BaseEntity, IStock
    {
        public IBook Item { get; set; }
        public ILocation? Location { get; set; }
        public bool Reserved { get; set; }
    }
}
