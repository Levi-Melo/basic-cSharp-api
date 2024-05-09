using basic_api.Data.Repositories;
using basic_api.Domain.Tenant.Controller;
using basic_api.Domain.Tenant.Facade;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Tenant.Controllers
{
    [ApiController]
    [Route("tenants")]
    public class TenantController(ITenantFacade facade) : ITenantController
    {
        private readonly ITenantFacade _facade = facade;

        [HttpGet, Route("[controller]")]
        public TenantModel Get(TenantGetModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public IEnumerable<TenantModel> Get(GetManyParams<TenantGetModel> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public TenantModel Insert(TenantModel entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public IEnumerable<TenantModel> Insert(IEnumerable<TenantModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public TenantModel Update(TenantUpdateModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public IEnumerable<TenantModel> Update(IEnumerable<TenantUpdateModel> input)
        {
            return _facade.Update(input);
        }

        [HttpDelete, Route("[controller]")]
        public void Delete(TenantGetModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public void Delete(IEnumerable<TenantGetModel> input)
        {
            _facade.Delete(input);
        }
    }
}
