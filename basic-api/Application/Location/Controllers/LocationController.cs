using basic_api.Controllers;
using basic_api.Data.Repositories;
using basic_api.Domain.Genre.Facade;
using basic_api.Domain.Location.Controllers;
using basic_api.Domain.Location.Facade;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Location.Controllers
{
    [ApiController]
    [Route("locations")]
    public class LocationController(ILocationFacade facade) : Controller<LocationModel>(), ILocationController
    {
        readonly ILocationFacade _facade = facade;

        [HttpDelete, Route("[controller]")]
        public override void Delete(LocationModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public override void Delete(IEnumerable<LocationModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public override LocationModel Get(LocationModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public override IEnumerable<LocationModel> Get(GetManyParams<LocationModel> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public override LocationModel Insert(LocationModel entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public override IEnumerable<LocationModel> Insert(IEnumerable<LocationModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public override LocationModel Update(LocationModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public override IEnumerable<LocationModel> Update(IEnumerable<LocationModel> input)
        {
            return _facade.Update(input);
        }
    }
}
