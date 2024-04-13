using basic_api.Controllers;
using basic_api.Domain.Publisher.Controllers;
using basic_api.Domain.Publisher.Facade;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Publisher.Controllers
{
    [ApiController]
    [Route("publishers")]
    public class PublisherController(IPublisherFacade facade) : Controller<PublisherModel>(facade), IPublisherController
    {
    }
}
