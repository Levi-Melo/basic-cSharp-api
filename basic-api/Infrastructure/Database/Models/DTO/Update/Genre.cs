using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Infrastructure.Database.Models.DTO.Update
{
    public class GenreUpdateModel : GenreGetModel
    {
        public Guid Id { get; set; }

        public IEnumerable<BookUpdateModel>? Books { get; set; }

        public IEnumerable<WriterUpdateModel>? Writers { get; set; }

        public TenantUpdateModel? Tenant { get; set; }
    }
}
