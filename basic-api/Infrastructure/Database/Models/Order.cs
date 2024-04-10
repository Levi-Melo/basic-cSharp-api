using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class OrderModel : BaseEntity, IOrder
    {
        public IEnumerable<BookModel> Books { get; set; }
        
        public bool? Accept { get; set; }

        public IEnumerable<BookModel> InvalidBooks { get; set; }

        public IEnumerable<StockModel> StockBooks { get; set; }

        public DateTime? DevolveAt{ get; set; }

        public bool? Devolved{ get; set; }

        public AccountModel OrderAuthor { get; set; }

    }
}
