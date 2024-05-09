
namespace basic_api.Infrastructure.Database.Models.DTO.Get
{
    public class OrderGetModel : OrderModel
    {
        public Guid? Id { get; set; }

        public IEnumerable<BookGetModel>? Books { get; set; }
        
        public bool? Accept { get; set; }

        public IEnumerable<BookGetModel>? InvalidBooks { get; set; }

        public IEnumerable<StockGetModel>? StockBooks { get; set; }

        public DateTime? DevolveAt{ get; set; }

        public bool? Devolved{ get; set; }

        public AccountGetModel? OrderAuthor { get; set; }

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
