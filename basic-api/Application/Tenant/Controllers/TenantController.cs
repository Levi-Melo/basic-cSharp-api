using basic_api.Data.Entities;
using basic_api.Domain.Tenant.Controller;
using basic_api.Domain.Tenant.Facade;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Tenant.Controllers
{
    [ApiController]
    [Route("tenants")]
    public class TenantController(ITenantFacade facade) : ITenantController
    {
        private readonly ITenantFacade _facade = facade;

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
