using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Infrastructure.Database.Models.DTO.Update
{
    public class BookUpdateModel : BookGetModel
    {
        public Guid Id { get; set; }

        public WriterUpdateModel? Ilustrator { get; set; }
        
        public PublisherUpdateModel? Publisher { get; set; }
    }
}
