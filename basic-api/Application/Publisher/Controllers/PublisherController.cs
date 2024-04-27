using basic_api.Controllers;
using basic_api.Data.Repositories;
using basic_api.Domain.Book.Facade;
using basic_api.Domain.Publisher.Controllers;
using basic_api.Domain.Publisher.Facade;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Publisher.Controllers
{
    [ApiController]
    [Route("publishers")]
    public class PublisherController(IPublisherFacade facade) : Controller<PublisherModel>(), IPublisherController
    {
        readonly IPublisherFacade _facade = facade;

        [HttpDelete, Route("[controller]")]
        public override void Delete(PublisherModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public override void Delete(IEnumerable<PublisherModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public override PublisherModel Get(PublisherModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public override IEnumerable<PublisherModel> Get(GetManyParams<PublisherModel> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public override PublisherModel Insert(PublisherModel entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public override IEnumerable<PublisherModel> Insert(IEnumerable<PublisherModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public override PublisherModel Update(PublisherModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public override IEnumerable<PublisherModel> Update(IEnumerable<PublisherModel> input)
        {
            return _facade.Update(input);
        }
    }
}
