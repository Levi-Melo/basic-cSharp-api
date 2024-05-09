using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Infrastructure.Database.Models.DTO.Update
{
    public class LocationUpdateModel : LocationGetModel
    { 
        public Guid Id { get; set; }

        public IEnumerable<StockUpdateModel>? Books { get; set; }

        public TenantUpdateModel? Tenant { get; set; }

    }
}