using basic_api.Domain.Base.Controller;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Update;
using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Domain.Book.Controllers
{
    public interface IBookController : IController<BookModel, BookGetModel, BookUpdateModel>
    {
    }
}
