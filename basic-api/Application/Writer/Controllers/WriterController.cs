using basic_api.Application.Writer.Facade;
using basic_api.Controllers;
using basic_api.Domain.Base.Facade;
using basic_api.Domain.Writer.Controllers;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Writer.Controllers
{
    [ApiController]
    [Route("writers")]
    public class WriterController(WriterFacade facade) : Controller<WriterModel>(facade), IWriterController
    {
    }
}
