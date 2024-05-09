namespace basic_api.Infrastructure.Database.Models.DTO.Get
{
    public class StockGetModel : StockModel
    {
        public Guid? Id { get; set; }

        public BookGetModel? Item { get; set; }

        public LocationGetModel? Location { get; set; }

        public bool? HaveFile { get; set; }

        public bool? Reserved { get; set; }

        public IEnumerable<OrderGetModel>? Orders { get; set; }

        public TenantGetModel? Tenant { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public DateTime? Deleted_at { get; set; }

        public List<Guid>? Updated_id { get; set; }

        public Guid? Created_id { get; set; }

        public List<Guid>? Deleted_id { get; set; }

        public bool? Deleted { get; set; }
    }
}
