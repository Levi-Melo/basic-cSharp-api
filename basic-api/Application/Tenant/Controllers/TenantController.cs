using basic_api.Application.Base;
using basic_api.Data.Entities;
using basic_api.Domain.Base.Controller;
using basic_api.Domain.Base.Facade;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Controllers
{
    [ApiController]
    [Route("tenants")]
    public class TenantController(TenantFacade facade) : ITenantController
    {
        private readonly TenantFacade _facade = facade;

        [HttpGet(Name = "")]
        public ITenant Get(ITenant input)
        {
            return _facade.Get(input);
        }

        [HttpGet(Name = "")]
        public IEnumerable<ITenant> Get(IEnumerable<ITenant> input)
        {
            return _facade.Get(input);
        }

        [HttpPost(Name = "")]
        public ITenant Insert(ITenant entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost(Name = "")]
        public IEnumerable<ITenant> Insert(IEnumerable<ITenant> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch(Name = "")]
        public ITenant Update(ITenant entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch(Name = "")]
        public IEnumerable<ITenant> Update(IEnumerable<ITenant> input)
        {
            return _facade.Update(input);
        }

        [HttpDelete(Name = "")]
        public void Delete(ITenant entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete(Name = "")]
        public void Delete(IEnumerable<ITenant> input)
        {
            _facade.Delete(input);
        }
    }
}
