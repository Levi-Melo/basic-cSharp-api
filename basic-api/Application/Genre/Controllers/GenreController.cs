using basic_api.Controllers;
using basic_api.Domain.Base.Facade;
using basic_api.Domain.Genre.Controllers;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Genre.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenreController(IFacade<GenreModel> facade) : Controller<GenreModel>(facade), IGenreController
    {
    }
}
