using basic_api.Controllers;
using basic_api.Data.Repositories;
using basic_api.Domain.Publisher.Controllers;
using basic_api.Domain.Publisher.Facade;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Publisher.Controllers
{
    [ApiController]
    [Route("publishers")]
    public class PublisherController(IPublisherFacade facade) : Controller<PublisherModel, PublisherGetModel, PublisherUpdateModel>(), IPublisherController
    {
        readonly IPublisherFacade _facade = facade;

        [HttpDelete, Route("[controller]")]
        public override void Delete(PublisherGetModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public override void Delete(IEnumerable<PublisherGetModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public override PublisherModel Get(PublisherGetModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public override IEnumerable<PublisherModel> Get(GetManyParams<PublisherGetModel> input)
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
        public override PublisherModel Update(PublisherUpdateModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public override IEnumerable<PublisherModel> Update(IEnumerable<PublisherUpdateModel> input)
        {
            return _facade.Update(input);
        }
    }
}
