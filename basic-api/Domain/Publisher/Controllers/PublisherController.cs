using basic_api.Domain.Base.Controller;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Domain.Publisher.Controllers
{
    public interface IPublisherController : IController<PublisherModel, PublisherGetModel, PublisherUpdateModel>
    {
    }
}
