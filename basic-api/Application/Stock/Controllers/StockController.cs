using basic_api.Controllers;
using basic_api.Data.Repositories;
using basic_api.Domain.Stock.Controllers;
using basic_api.Domain.Stock.Facade;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Stock.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class StockController(IStockFacade facade) : Controller<StockModel, StockGetModel, StockUpdateModel>, IStockController
    {
        readonly IStockFacade _facade = facade;

        [HttpDelete, Route("[controller]")]
        public override void Delete(StockGetModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public override void Delete(IEnumerable<StockGetModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public override StockModel Get(StockGetModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public override IEnumerable<StockModel> Get(GetManyParams<StockGetModel> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public override StockModel Insert(StockModel entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public override IEnumerable<StockModel> Insert(IEnumerable<StockModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public override StockModel Update(StockUpdateModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public override IEnumerable<StockModel> Update(IEnumerable<StockUpdateModel> input)
        {
            return _facade.Update(input);
        }
    }
}
