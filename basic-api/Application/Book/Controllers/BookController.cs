using basic_api.Controllers;
using basic_api.Domain.Book.Controllers;
using basic_api.Domain.Book.Facade;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Book.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController(IBookFacade facade) : Controller<BookModel>(facade), IBookController
    {
    }
}
