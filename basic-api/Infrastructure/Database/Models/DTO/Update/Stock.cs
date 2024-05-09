using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Infrastructure.Database.Models.DTO.Update
{
    public class StockUpdateModel : StockGetModel
    {
        public Guid Id { get; set; }

        public BookUpdateModel? Item { get; set; }

        public LocationUpdateModel? Location { get; set; }

        public IEnumerable<OrderUpdateModel>? Orders { get; set; }

        public TenantUpdateModel? Tenant { get; set; }

    }
}
