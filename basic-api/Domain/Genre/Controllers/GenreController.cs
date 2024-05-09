using basic_api.Domain.Base.Controller;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Update;
using basic_api.Infrastructure.Database.Models.DTO.Get;

namespace basic_api.Domain.Genre.Controllers
{
    public interface IGenreController : IController<GenreModel, GenreGetModel, GenreUpdateModel>
    {
    }
}
