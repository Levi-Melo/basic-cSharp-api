using basic_api.Controllers;
using basic_api.Domain.Base.Facade;
using basic_api.Domain.Book.Controllers;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Book.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController(IFacade<BookModel> facade) : Controller<BookModel>(facade), IBookController
    {
    }
}
