using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Infrastructure.Database.Models.DTO.Update
{
    public class WriterUpdateModel : WriterGetModel
    {
        public Guid Id { get; set; }

        public IEnumerable<BookUpdateModel>? Books { get; set; }

        public IEnumerable<GenreUpdateModel>? Genres { get; set; }

        public TenantUpdateModel? Tenant { get; set; }

    }
}
