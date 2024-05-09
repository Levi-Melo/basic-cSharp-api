using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Infrastructure.Database.Models.DTO.Update
{
    public class OrderUpdateModel : OrderGetModel
    {
        public Guid Id { get; set; }

        public IEnumerable<BookUpdateModel> Books { get; set; }
        
        public IEnumerable<BookUpdateModel> InvalidBooks { get; set; }

        public IEnumerable<StockUpdateModel> StockBooks { get; set; }

        public AccountUpdateModel OrderAuthor { get; set; }

        public TenantUpdateModel? Tenant { get; set; }


    }
}
