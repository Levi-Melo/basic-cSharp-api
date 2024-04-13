using basic_api.Controllers;
using basic_api.Domain.Genre.Controllers;
using basic_api.Domain.Genre.Facade;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Genre.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenreController(IGenreFacade facade) : Controller<GenreModel>(facade), IGenreController
    {
    }
}
