using basic_api.Application.Publisher.Facade;
using basic_api.Controllers;
using basic_api.Domain.Base.Facade;
using basic_api.Domain.Publisher.Controllers;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Publisher.Controllers
{
    [ApiController]
    [Route("publishers")]
    public class PublisherController(PublisherFacade facade) : Controller<PublisherModel>(facade), IPublisherController
    {
    }
}
